namespace FootballManager.Controllers
{
    using FootballManager.Data;
    using FootballManager.Data.Models;
    using FootballManager.Services;
    using FootballManager.ViewModels.Palyers;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Collections.Generic;
    using System.Linq;

    public class PlayersController : Controller
    {
        public readonly FootballManagerDbContext data;
        public readonly IValidator validator;
        public PlayersController(FootballManagerDbContext data, IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse All()
        {
            var players = this.data.Players
                .Select(p => new AllPlayersModel
                {
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    FullName = p.FullName,
                    Speed = p.Speed,
                    Endurance = p.Endurance,
                    Position = p.Position,
                    Description = p.Description
                }).ToList();

            return this.View(players);
        }

        [Authorize]
        public HttpResponse Add() => this.View();

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddPlayerFormModel model)
        {
            var modelErrors = this.validator.IsValidAddPlayerFormModel(model);

            
            if (modelErrors.Any())
            {
                return View("/Error", modelErrors);
            }

            var player = new Player
            {
                ImageUrl = model.ImageUrl,
                FullName = model.FullName,
                Speed = model.Speed,
                Endurance = model.Endurance,
                Position = model.Position,
                Description = model.Description
            };

            this.data.Players.Add(player);
            this.data.SaveChanges();

            var userPalyer = new UserPalyer
            {
                PlayerId = player.Id,
                UserId = this.User.Id
            };

            this.data.UserPalyers.Add(userPalyer);
            this.data.SaveChanges();

            return Redirect("/Players/All");
        }

        public HttpResponse AddToCollection(int playerId)
        {
            var userPalyer = new UserPalyer
            {
                PlayerId = playerId,
                UserId = this.User.Id
            };

            this.data.UserPalyers.Add(userPalyer);
            this.data.SaveChanges();

            return Redirect("/Players/All");
        }

        public HttpResponse RemoveFromCollection(int playerId)
        {
            var modelErrors = new List<string>();

            var player = this.data.Players
                .Where(p => p.Id == playerId)
                .FirstOrDefault();

            if (player == null)
            {
                modelErrors.Add("Palyer does not exist!");
            }
            if (!this.data.UserPalyers.Any(x => x.PlayerId == playerId && x.UserId == this.User.Id))
            {
                modelErrors.Add("Palyer is not in collection!");
            }
            if (modelErrors.Count > 0)
            {
                return View("/Error", modelErrors);
            }

            var palyerToRemove = this.data.UserPalyers
                .Where(x => x.PlayerId == player.Id)
                .FirstOrDefault();

            this.data.UserPalyers.Remove(palyerToRemove);
            this.data.SaveChanges();

            return Redirect("/Players/Collection");
        }

        [Authorize]
        public HttpResponse Collection()
        {
            var myPlayers = new List<Player>();

            var playersId = this.data.UserPalyers
                .Where(u => this.User.Id == u.UserId)
                .Select(p => p.PlayerId)
                .ToList();

            foreach (var id in playersId)
            {
                var player = this.data.Players
                .Where(p => p.Id == id)
                .Select(p => new Player
                {
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    FullName = p.FullName,
                    Speed = p.Speed,
                    Endurance = p.Endurance,
                    Position = p.Position,
                    Description = p.Description
                }).FirstOrDefault();

                myPlayers.Add(player);
            }

            return this.View(myPlayers);
        }
    }
}

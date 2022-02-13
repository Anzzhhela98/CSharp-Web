namespace SharedTrip.Controllers
{
    using MyWebServer.Http;
    using MyWebServer.Controllers;
    using SharedTrip.Data;
    using System.Linq;
    using SharedTrip.ViewModel;
    using SharedTrip.Services;
    using SharedTrip.Models;
    using System.Collections.Generic;

    public class TripsController : Controller
    {
        public readonly ApplicationDbContext data;
        public readonly IValidator validator;

        public TripsController(ApplicationDbContext data, IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse All()
        {
            var allTrips = this.data.Trips.Select(t => new TripsAllModel
            {
                Id = t.Id,
                StartPoint = t.StartPoint,
                EndPoint = t.EndPoint,
                Seats = t.Seats,
                DepartureTime = t.DepartureTime,
                Description = t.Description,
            }).ToList();

            return this.View(allTrips);
        }

        [Authorize]
        public HttpResponse Add()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(TripsAddFormModel model)
        {
            var modelErrors = this.validator.IsValidTripFormModel(model);

            if (modelErrors.Any())
            {
                return View("/Error", modelErrors);
            }

            var trip = new Trip()
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                DepartureTime = model.DepartureTime,
                Description = model.Description,
                Seats = model.Seats,
                ImagePath = model.ImagePath
            };

            this.data.Trips.Add(trip);
            this.data.SaveChanges();

            return this.Redirect("All");
        }

        [Authorize]
        public HttpResponse Details(string tripId)
        {
            var modelErrors =  new List<string>();

            var currTrip = this.data.Trips
                .Where(t => t.Id == tripId).Any();

            if (!currTrip)
            {
                modelErrors.Add("Trip does not exist!");

                return View("Error", modelErrors);
            }

            var existingTrip = this.data.Trips
                .Where(t => t.Id == tripId)
                .Select(t => new TripDetailsViewModel
                {
                    Id = t.Id,
                    ImagePath = t.ImagePath,
                    Description = t.Description,
                    EndPoint = t.EndPoint,
                    StartPoint = t.StartPoint,
                    Seats = t.Seats,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                }).FirstOrDefault();

            return this.View(existingTrip);
        }

        [Authorize]
        public HttpResponse AddUserToTrip(string tripId)
        {
            var modelErrors = new List<string>();

            var currTrip = this.data.Trips
                .Where(t => t.Id == tripId).Any();

            if (!currTrip)
            {
                modelErrors.Add("Trip does not exist!");

                return View("Error", modelErrors);
            }

            var userTrip = new UserTrip
            {
                TripId = tripId,
                UserId = this.User.Id
            };

            if (this.data.UserTrips.Where(ut => ut.UserId == this.User.Id && ut.TripId == tripId).Any())
            {
                modelErrors.Add("You are alredy in the trip!");

                return View("/Error", modelErrors);
            }

            this.data.UserTrips.Add(userTrip);
            this.data.SaveChanges();

            return Redirect("/");
        }
    }
}

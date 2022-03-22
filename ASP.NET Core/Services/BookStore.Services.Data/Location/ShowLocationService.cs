namespace BookStore.Services.Data.Location
{
    using System.Collections.Generic;
    using System.Linq;

    using BookStore.Data;
    using BookStore.Web.ViewModels.Location;

    public class ShowLocationService : IShowLocationService
    {
        private readonly ApplicationDbContext db;

        public ShowLocationService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<LocationViewModel> AllLocation()
        {
            var locations = this.db.StoreLocations
                .Select(l => new LocationViewModel
                {
                    Id = l.Id,
                    Name = l.Name,
                    PhoneNumber = l.PhoneNumber,
                    Email = l.Email,
                    Address = l.Address,
                    Image = l.Image,
                }).ToList();

            return locations;
        }
    }
}

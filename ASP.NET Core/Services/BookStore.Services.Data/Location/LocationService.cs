namespace BookStore.Services.Data.Location
{
    using System.Collections.Generic;
    using System.Linq;

    using BookStore.Data;
    using BookStore.Web.ViewModels.Location;

    public class LocationService : ILocationService
    {
        private readonly ApplicationDbContext db;

        public LocationService(ApplicationDbContext db)
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

        public LocationByIdViewModel LocationById(int id)
        {
            var locationById = this.db.StoreLocations
                .Where(l => l.Id == id)
                .Select(l => new LocationByIdViewModel
                {
                    Name = l.Name,
                    Address = l.Address,
                    PhoneNumber = l.PhoneNumber,
                    Email = l.Email,
                    WorkingTime = l.WorkingTime,
                    Image = l.Image,
                }).FirstOrDefault();

            return locationById;
        }
    }
}

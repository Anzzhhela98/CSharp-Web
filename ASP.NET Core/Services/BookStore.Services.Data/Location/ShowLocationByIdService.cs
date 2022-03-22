namespace BookStore.Services.Data.Location
{
    using System.Linq;

    using BookStore.Data;
    using BookStore.Web.ViewModels.Location;

    public class ShowLocationByIdService : IShowLocationByIdService
    {
        private readonly ApplicationDbContext db;

        public ShowLocationByIdService(ApplicationDbContext db)
        {
            this.db = db;
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

namespace BookStore.Web.Controllers.Location
{
    using BookStore.Services.Data.Location;
    using Microsoft.AspNetCore.Mvc;

    public class LocationController : Controller
    {
        private readonly IShowLocationService showLocation;
        private readonly IShowLocationByIdService showLocationById;

        public LocationController(IShowLocationService showLocation, IShowLocationByIdService showLocationById)
        {
            this.showLocation = showLocation;
            this.showLocationById = showLocationById;
        }

        public IActionResult ShowLocation()
        {
            var locations = this.showLocation.AllLocation();

            return this.View(locations);
        }

        public IActionResult LocationById(int id)
        {
            var location = this.showLocationById.LocationById(id);

            return this.View(location);
        }
    }
}

namespace BookStore.Web.Controllers.Location
{
    using BookStore.Services.Data.Location;
    using Microsoft.AspNetCore.Mvc;

    public class LocationController : Controller
    {
        private readonly ILocationService locationService;

        public LocationController(ILocationService locationService)
        {
            this.locationService = locationService;
        }

        [HttpGet]
        public IActionResult ShowLocation()
        {
            var locations = this.locationService.AllLocation();

            return this.View(locations);
        }

        [HttpGet]
        public IActionResult LocationById(int id)
        {
            var location = this.locationService.LocationById(id);

            if (location == null)
            {
                return this.Redirect("~/PageNotFount");
            }

            return this.View(location);
        }
    }
}

namespace CarShop.Controllers
{
    using CarShop.Data;
    using CarShop.Data.Models;
    using CarShop.Models.Cars;
    using CarShop.Services;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class CarsController : Controller
    {
        private readonly IValidator validator;
        private readonly CarShopDbContext data;

        public CarsController(IValidator validator, CarShopDbContext data)
        {
            this.validator = validator;
            this.data = data;
        }

        [Authorize]
        public HttpResponse Add()
        {
            bool userIsMechanic = isMechanic();

            if (userIsMechanic)
            {
                return Unauthorized();
            };

            return View();
        }


        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddCarFormModel model)
        {
            var modelErrors = this.validator.IsValidFomCar(model);

            if (modelErrors.Any())
            {
                return View("./Shared/Error", modelErrors);
            }

            var car = new Car
            {
                Model = model.Model,
                Year = model.Year,
                PictureUrl = model.Image,
                PlateNumber = model.PlateNumber,
                OwnerId = this.User.Id,
            };

            this.data.Cars.Add(car);
            this.data.SaveChanges();

            return Redirect("/Cars/All");
        }
        public HttpResponse All()
        {
            List<CarListingViewModel> cars;

            if (this.isMechanic())
            {
                cars = this.data.Cars
               .Where(c => c.Issues.Any(i => !i.IsFixed))
                 .Select(c => new CarListingViewModel
                 {
                     Id = c.Id,
                     Model = c.Model,
                     Year = c.Year,
                     Image = c.PictureUrl,
                     PlateNumber = c.PlateNumber,
                     FixedIssues = c.Issues.Where(i => i.IsFixed).Count(),
                     RemainingIssues = c.Issues.Where(i => !i.IsFixed).Count(),
                 })
               .ToList();
            }
            else
            {
                cars = this.data.Cars
                   .Where(u => u.OwnerId == this.User.Id)
                   .Select(c => new CarListingViewModel
                   {
                       Id = c.Id,
                       Model = c.Model,
                       Year = c.Year,
                       Image = c.PictureUrl,
                       PlateNumber = c.PlateNumber,
                       FixedIssues = c.Issues.Where(i => i.IsFixed).Count(),
                       RemainingIssues = c.Issues.Where(i => !i.IsFixed).Count(),
                   })
                   .ToList();
            }


            return View("/Cars/All", cars);
        }

        private bool isMechanic()
        {
            return this.data.Users
                .Any(u => this.User.Id == u.Id && u.IsMechanic);
        }
    }
}

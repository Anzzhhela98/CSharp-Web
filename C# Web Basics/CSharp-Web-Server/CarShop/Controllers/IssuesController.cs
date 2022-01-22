namespace CarShop.Controllers
{
    using CarShop.Data;
    using CarShop.Data.Models;
    using CarShop.Models.Issues;
    using CarShop.Services;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class IssuesController : Controller
    {
        private readonly CarShopDbContext data;
        private readonly IValidator validator;
        public IssuesController(CarShopDbContext data, IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        public HttpResponse CarIssues(string carId)
        {
            var carIssues = this.data
              .Cars
              .Where(i => i.Id == carId)
              .Select(c => new CarIssuesViewModel
              {
                  Id = c.Id,
                  Model = c.Model,
                  Year = c.Year,
                  //UserIsMechanic = this.users.IsMechanic(this.User.Id),
                  Issues = c.Issues.Select(i => new IssueListingViewModel
                  {
                      Id = i.Id,
                      Description = i.Description,
                      IsFixed = i.IsFixed,
                      IsFixedInformation = i.IsFixed ? "Yes" : "Not Yet"
                  })
              })
              .FirstOrDefault();

            //if (carIssues == null)
            //{
            //    var modelErrors = new List<string>();
            //    modelErrors.Add("This car does not have any issues!");

            //    return View("./Shared/Error", modelErrors);
            //}

            return View(carIssues);
        }

        [Authorize]
        public HttpResponse Add(string carId) => View(new AddIssueViewModel //?
        {
            CarId = carId
        });

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddIssuesFormModel model)
        {
            var modelErrors = this.validator.IsValidIssueForm(model);

            if (modelErrors.Any())
            {
                return View("./Shared/Error", modelErrors);
            }

            var issue = new Issue
            {
                Description = model.Description,
                CarId = model.CarId,
            };

            data.Issues.Add(issue);

            data.SaveChanges();

            return Redirect($"/Issues/CarIssues?carId={model.CarId}");
        }

        [Authorize]
        public HttpResponse Fix(string issueId, string carId)
        {
            var user = this.data
                .Users
                .Where(u => u.Id == this.User.Id)
                .FirstOrDefault();

            if (!user.IsMechanic)
            {
                return Unauthorized();
            }

            var issue = this.data.Issues.Find(issueId);

            issue.IsFixed = true;

            this.data.SaveChanges();

            return Redirect($"/Issues/CarIssues?carId={carId}");
        }

        [Authorize]
        public HttpResponse Delete(string issueId, string carId)
        {
            var issue = this.data.Issues.Find(issueId);

            this.data.Issues.Remove(issue);

            this.data.SaveChanges();

            return Redirect($"/Issues/CarIssues?carId={carId}");
        }
    }
}

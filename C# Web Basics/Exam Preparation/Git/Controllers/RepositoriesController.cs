namespace Git.Controllers
{
    using Git.Data;
    using MyWebServer.Http;
    using MyWebServer.Controllers;
    using Git.Services;
    using Git.ViewModels;
    using Git.Data.Models;

    public class RepositoriesController : Controller
    {
        public readonly ApplicationDbContext data;
        public readonly IValidator validator;

        public RepositoriesController(ApplicationDbContext data, IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        public HttpResponse All()
        {
            var user = this.data.Users
                .Where(u => u.Id == this.User.Id)
                .Select(u => u.Id)
                .FirstOrDefault();

            var publicRepositories = data.Repositories
                .Where(u => u.OwnerId == user || u.IsPublic == true)
                .Select(r => new RepositoryAllModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Owner = r.Owner.UserName,
                    CreatedOn = r.CreatedOn.ToString("yyyy-MM-dd"),
                    Commits = r.Commits.Count()
                }).ToList();

            return this.View(publicRepositories);
        }

        [Authorize]
        public HttpResponse Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public HttpResponse Create(CreateRepositoryModelForm model)
        {
            var modelErrors = this.validator.IsValidCreateRepositoryFormModel(model);

            if (modelErrors.Any())
            {
                return View("/Error", modelErrors);
            }

            var repository = new Repository
            {
                Name = model.Name,  
                CreatedOn = DateTime.Now,
                IsPublic = model.RepositoryType == "Public" ? true : false,
                OwnerId = this.User.Id,
            };

            this.data.Repositories.Add(repository);
            this.data.SaveChanges();

            return Redirect("/Repositories/All");
        }
    }
}

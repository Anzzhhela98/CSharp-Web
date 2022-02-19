namespace Git.Controllers
{
    using Git.Data;
    using Git.Data.Models;
    using Git.Services;
    using Git.ViewModels;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class CommitsController : Controller
    {
        public readonly ApplicationDbContext data;
        public readonly IValidator validator;

        public CommitsController(ApplicationDbContext data, IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        public HttpResponse Create() => this.View();

        [Authorize]
        [HttpPost]
        public HttpResponse Create(string Id, CreateCommitModelForm model)
        {
            var modelErrors = this.validator.IsValidCreateCommitFormModel(model);

            if (modelErrors.Any())
            {
                return View("/Error", modelErrors);
            }

            var commit = new Commit
            {
                Description = model.Description,
                CreatedOn = DateTime.UtcNow,
                CreatorId = this.User.Id,
                RepositoryId = Id,
            };

            var user = this.data.Users.Where(i => i.Id == this.User.Id).FirstOrDefault();

            this.data.Commits.Add(commit);
            this.data.SaveChanges();

            return Redirect("/Commits/All");
        }

        public HttpResponse All()
        {
            var commits = this.data.Commits
                    .Where(x => x.CreatorId == this.User.Id)
                    .Select(x => new MyCommitsModel
                    {
                        Id = x.Id,
                        Description = x.Description,
                        Repository = x.Repository.Name,
                        CreatedOn = x.CreatedOn.ToString("yyyy-MM-dd"),
                    }).ToList();

            return this.View(commits);
        }

        public HttpResponse Delete(string id)
        {
            var commit = this.data.Commits
                .Where(c => c.Id == id)
                .FirstOrDefault();

            this.data.Commits.Remove(commit);
            this.data.SaveChanges();

            return this.Redirect("/Repositories/All");
        }
    }
}

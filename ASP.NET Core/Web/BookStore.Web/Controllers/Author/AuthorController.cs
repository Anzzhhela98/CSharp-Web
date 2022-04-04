namespace BookStore.Web.Controllers
{
    using BookStore.Services.Data.Author;
    using BookStore.Web.ViewModels.Author;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class AuthorController : Controller
    {
        private readonly IAddAuthorInSystemService addAuthorInSystemService;

        public AuthorController(IAddAuthorInSystemService addAuthorInSystemService)
        {
            this.addAuthorInSystemService = addAuthorInSystemService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult RegistarAuthor()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult RegistarAuthor(RegistarAuthorModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            this.addAuthorInSystemService.AddAuthorInSystem(model);

            return this.Redirect("/Book/Create");
        }
    }
}

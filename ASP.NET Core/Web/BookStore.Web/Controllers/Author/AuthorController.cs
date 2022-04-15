namespace BookStore.Web.Controllers
{
    using System.Security.Claims;

    using BookStore.Services.Data.Book;
    using BookStore.Web.ViewModels.Author;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class AuthorController : Controller
    {
        private readonly IAuthorService authorService;
        private readonly IHttpContextAccessor httpContextAccessor;


        public AuthorController(IAuthorService authorService, IHttpContextAccessor httpContextAccessor)
        {
            this.authorService = authorService;
            this.httpContextAccessor = httpContextAccessor;
        }

        [Authorize]
        [HttpGet]
        public IActionResult RegistarAuthor() => this.View();

        [HttpPost]
        [Authorize]
        public IActionResult RegistarAuthor(RegistarAuthorModel model)
        {
            var userId = this.httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            this.authorService.AddAuthorInSystem(model, userId);

            return this.Redirect("/Book/Create");
        }
    }
}

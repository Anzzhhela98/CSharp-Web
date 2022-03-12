namespace BookStore.Web.Controllers
{
    using System.Security.Claims;

    using BookStore.Data.Models;
    using BookStore.Services.Data.Book;
    using BookStore.Web.ViewModels.Book;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class BookController : Controller
    {
        private readonly ICreateBookService createBookService;
        private readonly IAuthorizedToCreateBookService authorizedToCreateBook;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public BookController(ICreateBookService createBookService, UserManager<ApplicationUser> userManager, IAuthorizedToCreateBookService authorizedToCreateBook, IHttpContextAccessor httpContextAccessor)
        {
            this.createBookService = createBookService;
            this.userManager = userManager;
            this.authorizedToCreateBook = authorizedToCreateBook;
            this.httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Create()
        {
            var userId = this.httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var isAuthorizedToCreateBook = this.authorizedToCreateBook.IsAuthorizedToCreateBook(userId);

            if (!isAuthorizedToCreateBook)
            {
                return Redirect("/Author/RegistarAuthor");
            }

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateBookModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            this.createBookService.CreateBook(model);

            return this.Redirect("/");
        }
    }
}

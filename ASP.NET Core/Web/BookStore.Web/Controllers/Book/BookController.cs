namespace BookStore.Web.Controllers
{
    using System.Linq;
    using System.Security.Claims;

    using BookStore.Data.Models;
    using BookStore.Services.Data.Book;
    using BookStore.Web.ViewModels.Books;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class BookController : Controller
    {
        private readonly IAuthorService authorizedToCreateBook;
        private readonly IBooksService booksService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public BookController(UserManager<ApplicationUser> userManager, IAuthorService authorizedToCreateBook, IHttpContextAccessor httpContextAccessor, IBooksService booksService)
        {
            this.userManager = userManager;
            this.authorizedToCreateBook = authorizedToCreateBook;
            this.httpContextAccessor = httpContextAccessor;
            this.booksService = booksService;
        }

        [HttpGet]
        public IActionResult Promotional(int id = 1)
        {
            const int itemsPerPage = 6;

            var books = new BooksInListModel
            {
                ItemsPerPage = itemsPerPage,
                PageNumber = id,
                BooksCount = this.booksService.GetPromotionalBooksCount(),
                Books = this.booksService.GetAllPromotional(id, itemsPerPage),
            };

            if (books == null)
            {
                return this.Redirect("~/PageNotFount");
            }

            return this.View(books);
        }

        [HttpGet]
        public IActionResult All(int id = 1)
        {
            const int itemsPerPage = 6;

            var books = new BooksInListModel
            {
                ItemsPerPage = itemsPerPage,
                PageNumber = id,
                BooksCount = this.booksService.GetCount(),
                Books = this.booksService.GetAll(id, itemsPerPage),
            };

            if (books.Books.Count() == 0)
            {
                return this.Redirect("~/PageNotFount");
            }

            return this.View(books);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var book = this.booksService.GetById(id);

            if (book == null)
            {
                return this.Redirect("~/PageNotFound");
            }

            return this.View(book);
        }

        [HttpGet]
        public IActionResult Buy(int id)
        {
            if (id == 0)
            {
                return this.View("EmptyCart");
            }

            if (this.User.Identity.IsAuthenticated)
            {
                //var userId = this.httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var book = this.booksService.Buy(id);
                ;
                return this.View(book);
            }

            return this.Redirect("/Identity/Account/Login");
        }
    }
}

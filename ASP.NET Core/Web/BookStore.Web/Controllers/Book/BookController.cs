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
        private readonly IAuthorizedToCreateBookService authorizedToCreateBook;
        private readonly IBooksService booksService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public BookController(UserManager<ApplicationUser> userManager, IAuthorizedToCreateBookService authorizedToCreateBook, IHttpContextAccessor httpContextAccessor, IBooksService booksService)
        {
            this.userManager = userManager;
            this.authorizedToCreateBook = authorizedToCreateBook;
            this.httpContextAccessor = httpContextAccessor;
            this.booksService = booksService;
        }

        [Authorize]
        public IActionResult Create()
        {
            var userId = this.httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var isAuthorizedToCreateBook = this.authorizedToCreateBook.IsAuthorizedToCreateBook(userId);

            if (!isAuthorizedToCreateBook)
            {
                return this.Redirect("/Author/RegistarAuthor");
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

            this.booksService.CreateBook(model);

            return this.Redirect("/");
        }

        public IActionResult Promotional(int id = 1)
        {
            const int itemsPerPage = 4;

            var books = new BooksInListModel
            {
                ItemsPerPage = itemsPerPage,
                PageNumber = id,
                BooksCount = this.booksService.GetPromotionalBooksCount(),
                Books = this.booksService.GetAllPromotional(id, itemsPerPage),
            };
            ;
            return this.View(books);
        }

        public IActionResult All(int id = 1)
        {
            const int itemsPerPage = 4;

            var books = new BooksInListModel
            {
                ItemsPerPage = itemsPerPage,
                PageNumber = id,
                BooksCount = this.booksService.GetCount(),
                Books = this.booksService.GetAll(id, itemsPerPage),
            };
            ;
            return this.View(books);
        }

        public IActionResult GetById(int id)
        {
            var book = this.booksService.GetById(id);

            return this.View(book);
        }
    }
}

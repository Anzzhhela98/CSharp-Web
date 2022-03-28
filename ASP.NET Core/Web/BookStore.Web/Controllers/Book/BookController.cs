namespace BookStore.Web.Controllers
{
    using System.Linq;
    using System.Security.Claims;

    using BookStore.Data.Models;
    using BookStore.Services.Data.Book;
    using BookStore.Services.Data.Home;
    using BookStore.Web.ViewModels.Book;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class BookController : Controller
    {
        private readonly ICreateBookService createBookService;
        private readonly IAuthorizedToCreateBookService authorizedToCreateBook;
        private readonly IGetBookService promotionalBookService;
        private readonly IBooksService booksService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public BookController(ICreateBookService createBookService, UserManager<ApplicationUser> userManager, IAuthorizedToCreateBookService authorizedToCreateBook, IHttpContextAccessor httpContextAccessor, IGetBookService promotionalBookService,IBooksService booksService)
        {
            this.createBookService = createBookService;
            this.userManager = userManager;
            this.authorizedToCreateBook = authorizedToCreateBook;
            this.httpContextAccessor = httpContextAccessor;
            this.promotionalBookService = promotionalBookService;
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

            this.createBookService.CreateBook(model);

            return this.Redirect("/");
        }

        public IActionResult PromotionalBooks()
        {
            var promotionalBooks = this.promotionalBookService.GetPromotionalBooks();

            return this.View(promotionalBooks);
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

            return this.View(books);
        }
    }
}

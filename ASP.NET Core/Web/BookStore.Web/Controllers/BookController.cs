namespace BookStore.Web.Controllers
{
    using BookStore.Data.Models;
    using BookStore.Services.Data.Book;
    using BookStore.Web.ViewModels.Book;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class BookController : Controller
    {
        private readonly ICreateBookService createBookService;
        private readonly UserManager<ApplicationUser> userManager;

        public BookController(ICreateBookService createBookService, UserManager<ApplicationUser> userManager)
        {
            this.createBookService = createBookService; 
            this.userManager = userManager;
        }

        public IActionResult Create() => this.View();

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

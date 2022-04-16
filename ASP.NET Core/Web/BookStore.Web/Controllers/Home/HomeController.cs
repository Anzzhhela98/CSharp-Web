namespace BookStore.Web.Controllers
{
    using System.Diagnostics;

    using BookStore.Services.Data.Book;
    using BookStore.Web.ViewModels;

    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IBooksService booksService;

        public HomeController(IBooksService booksService)
        {
            this.booksService = booksService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var randomBooks = this.booksService.GetRandomBook();

            return this.View(randomBooks);
        }

        public IActionResult AboutUs()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        [Route("/NotFound")]
        public IActionResult PageNotFound()
        {
            return this.View();
        }
    }
}

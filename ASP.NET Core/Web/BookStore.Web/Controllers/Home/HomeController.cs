namespace BookStore.Web.Controllers
{
    using System.Diagnostics;

    using BookStore.Services.Data.Home;
    using BookStore.Web.ViewModels;

    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IGetAllBookService getAllBookService;

        public HomeController(IGetAllBookService getAllBookService)
        {
            this.getAllBookService = getAllBookService;
        }

        public IActionResult Index()
        {
            var books = this.getAllBookService.GetAll();

            return this.View(books);
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
    }
}

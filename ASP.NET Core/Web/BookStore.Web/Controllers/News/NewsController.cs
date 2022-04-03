namespace BookStore.Web.Controllers.News
{
    using Microsoft.AspNetCore.Mvc;

    public class NewsController : Controller
    {
        public IActionResult News()
        {
            return this.View();
        }
    }
}

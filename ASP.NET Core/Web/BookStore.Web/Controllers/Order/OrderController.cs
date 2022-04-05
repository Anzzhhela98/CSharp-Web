namespace BookStore.Web.Controllers.Order
{
    using Microsoft.AspNetCore.Mvc;

    public class OrderController : Controller
    {
        public IActionResult OrderMessage()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Form()
        {
            return this.View();
        }
    }
}

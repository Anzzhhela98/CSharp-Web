namespace BookStore.Web.Controllers.Payment
{
    using Microsoft.AspNetCore.Mvc;

    public class PaymentController : Controller
    {
        public IActionResult MethodOfPayment()
        {
            return this.View();
        }
    }
}

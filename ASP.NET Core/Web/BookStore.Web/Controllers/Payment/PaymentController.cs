namespace BookStore.Web.Controllers.Payment
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Stripe;

    public class PaymentController : Controller
    {
        public IActionResult MethodOfPayment()
        {
            return this.View();
        }

        //[HttpGet]
        //[Authorize]
        //public IActionResult Charge()
        //{
        //    return this.View();
        //}

        [HttpPost]
        [Authorize]
        public IActionResult Charge(string stripeEmail, string stripeToken, string id, string BookId)
        {
            ;
            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = 600 * 100,
                Description = "Test Payment",
                Currency = "EUR",
                Source = stripeToken,
            });
            

            if (charge.Status == "succeeded")
            {
                string balanceTransactionId = charge.BalanceTransactionId;
            }
            else
            {
                return this.View(); //TO DO..
            }

            return this.Redirect("~/Home/Index");
        }

    }
}

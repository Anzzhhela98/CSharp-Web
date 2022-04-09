namespace BookStore.Web.Controllers.Payment
{
    using BookStore.Services.Data.Payment;
    using BookStore.Web.ViewModels.Payment;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class PaymentController : Controller
    {
        private readonly IPaymentService paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        public IActionResult MethodOfPayment()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Charge(PaymentFromViewModel model)
        {
            var charge = this.paymentService.Charge(model);

            if (charge.Status == "succeeded")
            {
                string balanceTransactionId = charge.BalanceTransactionId;
            }
            else
            {
                return this.Redirect("~/Payment/ErrorMessage");
            }

            return this.Redirect("~/Home/Index");
        }
    }
}

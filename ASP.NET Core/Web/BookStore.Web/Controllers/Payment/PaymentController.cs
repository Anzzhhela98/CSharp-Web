namespace BookStore.Web.Controllers.Payment
{
    using BookStore.Services.Data.Book;
    using BookStore.Services.Data.Order;
    using BookStore.Services.Data.Payment;
    using BookStore.Web.ViewModels.Payment;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class PaymentController : Controller
    {
        private readonly IPaymentService paymentService;
        private readonly IOrdersService orderService;
        private readonly IBooksService booksService;

        public PaymentController(IPaymentService paymentService, IOrdersService orderService, IBooksService booksService)
        {
            this.paymentService = paymentService;
            this.orderService = orderService;
            this.booksService = booksService;
        }

        public IActionResult MethodOfPayment()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Charge(PaymentFromViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            if (!this.booksService.EnoughQuantity(model.Id, model.Count))
            {
                return this.Redirect("~/Payment/ErrorMessage");
            }

            var charge = this.paymentService.Charge(model);

            if (charge.Status == "succeeded")
            {
                this.orderService.SetOrder(model, charge.Status);
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

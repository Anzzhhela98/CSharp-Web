namespace BookStore.Web.Controllers.Payment
{
    using System.Security.Claims;

    using BookStore.Services.Data.Book;
    using BookStore.Services.Data.Order;
    using BookStore.Services.Data.Payment;
    using BookStore.Web.ViewModels.Payment;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class PaymentController : Controller
    {
        private readonly IPaymentService paymentService;
        private readonly IOrdersService orderService;
        private readonly IBooksService booksService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public PaymentController(IPaymentService paymentService, IOrdersService orderService, IBooksService booksService, IHttpContextAccessor httpContextAccessor)
        {
            this.paymentService = paymentService;
            this.orderService = orderService;
            this.booksService = booksService;
            this.httpContextAccessor = httpContextAccessor;
        }

        public IActionResult MethodOfPayment()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Charge(PaymentFromViewModel model)
        {
            var userId = this.httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (!this.booksService.EnoughQuantity(model.Id, model.Count))
            {
                return this.Redirect("~/Payment/ErrorMessage");
            }

            var charge = this.paymentService.Charge(model);

            if (charge.Status == "succeeded")
            {
                this.orderService.SetOrder(model, charge.Status, userId);
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

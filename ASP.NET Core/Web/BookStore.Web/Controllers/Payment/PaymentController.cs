namespace BookStore.Web.Controllers.Payment
{
    using BookStore.Web.ViewModels.Payment;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Stripe;
    using System.Collections.Generic;

    public class PaymentController : Controller
    {
        public IActionResult MethodOfPayment()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Charge(PaymentFromViewModel model)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = model.StripeEmail,
            });
            ;
            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = model.TotalPriceTransfer / 100,
                Description = "Test Payment",
                Currency = "EUR",
                Source = model.StripeToken,
                ReceiptEmail = model.StripeEmail,
            });
            ;

            if (charge.Status == "succeeded")
            {
                string balanceTransactionId = charge.BalanceTransactionId;
                //StripeConfiguration.ApiKey = "sk_test_51KkssRBK8vsMODVi3jyPUx64V0x8FkSa4AhKavRxq8I69ExETswbwE8SJnMG1XqkvbTvsUnQh592k7Vt4iS8PA5e0001UEjQGV";

                //var paymentIntents = new PaymentIntentService();
                //var createOptions = new PaymentIntentCreateOptions
                //{
                //    Amount = model.TotalPriceTransfer / 100,
                //    Currency = "eur",
                //    PaymentMethodTypes = new List<string> { "card" },
                //    ReceiptEmail = model.StripeEmail,
                //};

                //paymentIntents.Create(createOptions);

                ////var myCharge = new StripeChargeCreateOptions
                ////{
                ////    CustomerId = stripeCustomer.Id,
                ////    Currency = "gbp",
                ////    Amount = 1000,
                ////    ReceiptEmail = "customer@email.com"
                ////};
                ////var chargeService = new StripeC();
                //var stripeCharge = charges.Create(charge);

                ;
            }
            else
            {
                return this.Redirect("~/Payment/ErrorMessage"); //TO DO..
            }

            return this.Redirect("~/Home/Index");
        }

    }
}

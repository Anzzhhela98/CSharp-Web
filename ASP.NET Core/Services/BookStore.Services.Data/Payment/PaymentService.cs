namespace BookStore.Services.Data.Payment
{
    using System;
    using System.Linq;

    using BookStore.Data;
    using BookStore.Web.ViewModels.Payment;
    using Stripe;

    public class PaymentService : IPaymentService
    {
        private readonly ApplicationDbContext db;

        public PaymentService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public Charge Charge(PaymentFromViewModel model)
        {
            var price = 0M;

            if (model.Count >= 1 && model.Count <= 2)
            {
                var book = this.db.Books.Where(x => x.Id == model.Id).FirstOrDefault();
                price = (book.Price * model.Count) + 3.8M;
                model.TotalPriceTransfer = Convert.ToInt64(price * 100);
            }

            var paymentIntents = new PaymentIntentService();
            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = model.StripeEmail,
            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = model.TotalPriceTransfer != 0 ? model.TotalPriceTransfer : Convert.ToInt64(price * 100),
                Description = "Test Payment",
                Currency = "EUR",
                Source = model.StripeToken,
                ReceiptEmail = model.StripeEmail,
            });

            return charge;
        }
    }
}

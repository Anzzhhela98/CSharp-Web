namespace BookStore.Services.Data.Payment
{
    using BookStore.Web.ViewModels.Payment;
    using Stripe;

    public class PaymentService : IPaymentService
    {
        public Charge Charge(PaymentFromViewModel model)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = model.StripeEmail,
            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = model.TotalPriceTransfer ,
                Description = "Test Payment",
                Currency = "EUR",
                Source = model.StripeToken,
                ReceiptEmail = model.StripeEmail,
            });

            return charge;
        }
    }
}

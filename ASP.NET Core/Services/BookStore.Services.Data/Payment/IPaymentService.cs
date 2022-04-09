namespace BookStore.Services.Data.Payment
{
    using BookStore.Web.ViewModels.Payment;
    using Stripe;

    public interface IPaymentService
    {
        public Charge Charge(PaymentFromViewModel model);
    }
}

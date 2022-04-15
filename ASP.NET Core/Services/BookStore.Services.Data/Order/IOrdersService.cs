namespace BookStore.Services.Data.Order
{
    using BookStore.Web.ViewModels.Payment;

    public interface IOrdersService
    {
        public void SetOrder(PaymentFromViewModel model, string paymentStatus, string userId);
    }
}

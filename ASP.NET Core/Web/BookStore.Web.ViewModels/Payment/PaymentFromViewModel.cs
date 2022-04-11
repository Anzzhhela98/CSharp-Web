namespace BookStore.Web.ViewModels.Payment
{
    public class PaymentFromViewModel
    {
        public int Id { get; set; }

        public int Count { get; set; }

        public string FullName { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string Number { get; set; }

        public long TotalPriceTransfer { get; set; }

        public string StripeToken { get; set; }

        public string StripeEmail { get; set; }

    }

}
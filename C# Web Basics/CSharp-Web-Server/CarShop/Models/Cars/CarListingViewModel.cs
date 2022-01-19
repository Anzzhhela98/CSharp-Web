namespace CarShop.Models.Cars
{
    public class CarListingViewModel
    {
        public string Id { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public string Image { get; set; }

        public string PlateNumber { get; set; }

        public int FixedIssues { get; set; }

        public int RemainingIssues { get; set; }

    }
}

namespace SMS.ViewModels.Products
{
    using System.Collections.Generic;

    public class HomeAllProductView
    {
        public string UserName { get; set; }

        public List<HomeViewProduct> Products { get; set; } = new List<HomeViewProduct>();
    }
}

namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Data;
    using SMS.ViewModels.Products;
    using System.Linq;

    public class HomeController : Controller
    {
        private readonly SMSDbContext data;

        public HomeController(SMSDbContext data)
        {
            this.data = data;
        }

        public HttpResponse Index()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.View("Index");
            }
            else
            {
                var user = data.Users.Where(x => x.Id == this.User.Id).FirstOrDefault();

                var products = this.data.Products
                    .Select(x => new HomeViewProduct
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Price = x.Price,
                    }).ToList();

                var model = new HomeAllProductView
                {
                    UserName = user.UserName,
                    Products = products
                };

                return this.View("IndexLoggedIn", model);
            }
        }
    }
}
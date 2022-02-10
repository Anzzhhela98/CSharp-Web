namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Data;
    using SMS.ViewModels.Carts;
    using System.Linq;

    public class CartsController : Controller
    {
        public readonly SMSDbContext data;

        public CartsController(SMSDbContext data)
        {
            this.data = data;
        }

        public HttpResponse Details()
        {
            var user = this.data.Users
                .Where(u => u.Id == User.Id)
                .FirstOrDefault();

            var productsOfUser = this.data.Products
                .Where(c => c.CartId == user.CartId)
                .Select(p => new CartDetailsProduct
                {
                    Name = p.Name,
                    Price = p.Price,
                })
                .ToList();

            return this.View(productsOfUser);
        }

        public HttpResponse AddProduct(string productId)
        {
            var product = this.data.Products.Where(p => p.Id == productId).FirstOrDefault();
            var cart = data.Carts.Where(x => x.UserId == User.Id).FirstOrDefault();

            product.CartId = cart.Id;

            this.data.SaveChanges();

            return Redirect("/Carts/Details");
        }

        public HttpResponse Buy()
        {
            var cart = this.data.Carts.Where(c => c.UserId == User.Id).FirstOrDefault();
            var products = this.data.Products.Where(p => p.CartId == cart.Id).ToList();

            foreach (var item in products)
            {
                item.CartId = null;
            }

            this.data.SaveChanges();
            ;
            return Redirect("/");
        }
    }
}

namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Data;
    using SMS.Models;
    using SMS.Services;
    using SMS.ViewModels.Products;
    using System.Linq;

    public class ProductsController : Controller
    {
        private readonly IValidator validator;
        private readonly SMSDbContext data;

        public ProductsController(IValidator validator, SMSDbContext data)
        {
            this.validator = validator;
            this.data = data;
        }

        [Authorize]
        public HttpResponse Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Create(CreateProductForm model)
        {
            var modelErrors = this.validator.IsValidFormProduct(model);

            if (modelErrors.Any())
            {
                return View("/Error", modelErrors);
            }

            var product = new Product
            {
                Name = model.Name,
                Price = model.Price,
            };

            this.data.Products.Add(product);
            this.data.SaveChanges();

            return Redirect("/");
        }

    }
}

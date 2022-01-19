namespace CarShop.Controllers
{
    using CarShop.Data;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class IssuesController : Controller
    {
        private readonly CarShopDbContext data;
        public IssuesController(CarShopDbContext data)
        {
            this.data = data;
        }

        //public HttpResponse CarIssues(string carId)
        //{
        //    var car = this.data.Cars
        //         .Where(c => c.Id == carId)
        //         .Select(c => new Ca
        //         .ToList();
        //}

        public HttpResponse Add()
        {
            return View();
        }
    }
}

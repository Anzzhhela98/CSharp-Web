namespace BookStore.Web.Controllers.Contact
{
    using BookStore.Web.ViewModels.Administration.Dashboard;
    using Microsoft.AspNetCore.Mvc;

    public class ContactController : Controller
    {
        public IActionResult Contact()
        {
            return this.View();
        }

        //[HttpPost]
        //public IActionResult Contact(IndexViewModel model)
        //{
        //    return this.View();
        //}
    }
}

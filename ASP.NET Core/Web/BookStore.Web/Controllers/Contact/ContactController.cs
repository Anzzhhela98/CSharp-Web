namespace BookStore.Web.Controllers.Contact
{
    using System.Security.Claims;

    using BookStore.Services.Data.Contact;
    using BookStore.Web.ViewModels.Contact;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class ContactController : Controller
    {
        private readonly IContactsService contactsService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ContactController(IContactsService contactsService, IHttpContextAccessor httpContextAccessor)
        {
            this.contactsService = contactsService;
            this.httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            ContactsViewModel data = new();

            if (this.User.Identity.IsAuthenticated)
            {
                var userId = this.httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var userData = this.contactsService.GetUserEmail(userId);
                data.Email = userData.Email;
            }

            return this.View(data);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Index(ContactsViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            return this.View();
        }

        public IActionResult Message()
        {
            return this.View();
        }
    }
}

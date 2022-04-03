namespace BookStore.Services.Data.Contact
{
    using System;
    using System.Linq;
    using BookStore.Data;
    using BookStore.Web.ViewModels.Contact;

    public class ContactsService : IContactsService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public ContactsService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public RegisteredUserViewModel GetUserEmail(string id)
        {
            var user = this.applicationDbContext
                .Users
                .Where(x => x.Id == id)
                .Select(x => new RegisteredUserViewModel
                {
                    Email = x.UserName,
                })
                .FirstOrDefault();

            return user;
        }
    }
}

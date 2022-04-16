namespace BookStore.Services.Data.Contact
{
    using System;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using BookStore.Data;
    using BookStore.Data.Models;
    using BookStore.Web.ViewModels.Contact;

    public class ContactsService : IContactsService
    {
        private readonly ApplicationDbContext db;

        public ContactsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public RegisteredUserViewModel GetUserEmail(string id)
        {
            var user = this.db
                .Users
                .Where(x => x.Id == id)
                .Select(x => new RegisteredUserViewModel
                {
                    Email = x.Email,
                })
                .FirstOrDefault();

            return user;
        }

        public void SetUserMessage(ContactsViewModel model)
        {
            var message = new UserQuestion
            {
                Email = model.Email,
                Question = model.Question,
                Phone = model.Phone,
                OrderNumber = model.OrderNumber,
                CreatedOn = DateTime.UtcNow,
            };

            this.db.UserQuestions.Add(message);
            this.db.SaveChanges();
        }
    }
}

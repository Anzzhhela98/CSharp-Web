namespace BookStore.Services.Data.Author
{
    using System.Linq;
    using System.Security.Claims;

    using BookStore.Data;
    using BookStore.Data.Models;
    using BookStore.Services.Data.Book;
    using BookStore.Web.ViewModels.Author;
    using Microsoft.AspNetCore.Http;

    public class AuthorService : IAuthorService
    {
        private readonly ApplicationDbContext db;

        public AuthorService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddAuthorInSystem(RegistarAuthorModel model, string userId)
        {
            var author = new SystemAuthor
            {
                Name = model.Name,
                Registrant = model.Registrant,
                CreatedByUserId = userId,
            };

            this.db.SystemAuthors.Add(author);
            this.db.SaveChanges();
        }

        public bool IsAuthorizedToCreateBook(string userId)
        {
            return this.db.SystemAuthors.Where(x => x.CreatedByUserId == userId && x.Registrant != null).Any();
        }
    }
}

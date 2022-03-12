namespace BookStore.Services.Data.Book
{
    using System.Linq;

    using BookStore.Data;

    public class AuthorizedToCreateBookService : IAuthorizedToCreateBookService
    {
        private readonly ApplicationDbContext db;

        public AuthorizedToCreateBookService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public bool IsAuthorizedToCreateBook(string userId)
        {
            return this.db.SystemAuthors.Where(x => x.CreatedByUserId == userId).Any();
        }
    }
}

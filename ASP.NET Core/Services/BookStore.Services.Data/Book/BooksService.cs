namespace BookStore.Services.Data.Book
{
    using System.Collections.Generic;
    using System.Linq;

    using BookStore.Data;
    using BookStore.Web.ViewModels.Book;

    public class BooksService : IBooksService
    {
        private readonly ApplicationDbContext db;

        public BooksService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<BookInListModel> GetAll(int page, int itemsPerPage = 4)
        {
            var book = this.db.Characteristics
         .Select(x => new BookInListModel
         {
             Price = x.Price.ToString(),
             Author = x.Author,
             Title = x.Title,
             ImageUrl = this.db.Images.Where(i => i.Id == x.ImageId).Select(x => x.ImageUrl).FirstOrDefault(),
             Id = x.Id,
         })
         .Skip((page - 1) * itemsPerPage)
         .Take(itemsPerPage)
         .ToList();

            return book;
        }

        public int GetCount()
        {
            return this.db.Books.Count();
        }
    }
}

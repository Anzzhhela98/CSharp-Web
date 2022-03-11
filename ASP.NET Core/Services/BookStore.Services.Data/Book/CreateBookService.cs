namespace BookStore.Services.Data.Book
{
    using System.Linq;
    using System.Security.Claims;

    using BookStore.Data;
    using BookStore.Data.Models;
    using BookStore.Web.ViewModels.Book;
    using Microsoft.AspNetCore.Http;

    public class CreateBookService : ICreateBookService
    {
        private readonly ApplicationDbContext db;
        private readonly IHttpContextAccessor httpContextAccessor;

        public CreateBookService(ApplicationDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            this.db = db;
            this.httpContextAccessor = httpContextAccessor;
        }

        public void CreateBook(CreateBookModel input)
        {
            var userId = this.httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var categoryId = this.db.Categories
                .Where(c => c.Type == input.Type)
                .Select(c => c.Id)
                .FirstOrDefault();

            var image = new Image
            {
                ImageUrl = input.ImageURl,
                Extension = "JPG",
                CreatedByUserId = userId,
            };

            this.db.Images.Add(image);
            this.db.SaveChanges();

            var characteristic = new Characteristic
            {
                Author = input.Author,
                Title = input.Title,
                Description = input.Description,
                Pages = input.Pages,
                Cover = input.Cover,
                Language = input.Language,
                Quantity = input.Quantity,
                Price = input.Price,
                Year = input.Year,
                DateOfPublication = input.DateOfPublication,
                ISBN = input.ISBN,
                UniqueIdBook = input.IdOfBook,
                ImageId = image.Id,
            };

            this.db.Characteristics.Add(characteristic);
            this.db.SaveChanges();

            var book = new Book
            {
                CharacteristicId = characteristic.Id,
                CreatedByUserId = userId,
            };

            this.db.Books.Add(book);
            this.db.SaveChanges();

            var bookCategories = new BookCategories
            {
                CategoryId = categoryId,
                BookId = book.Id,
            };

            book.BookCategories.Add(bookCategories);

            this.db.BookCategories.Add(bookCategories);

            this.db.SaveChanges();
        }
    }
}

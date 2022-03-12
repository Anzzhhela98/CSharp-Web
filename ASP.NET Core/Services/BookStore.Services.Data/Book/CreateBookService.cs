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

            var isb = input.ISBN.Split("-").ToArray();
            ;
            //ISBN 978 - 954 - 27 - 2741 - 5
            var newIsbn = new InternationalStandardBookNumber
            {
                Prefix = isb[0],
                RegistrationGroup = isb[1],
                Registrant = isb[2],
                Edition = isb[3],
                CheckDigit = isb[4],
            };

            this.db.InternationalStandardBookNumbers.Add(newIsbn);
            this.db.SaveChanges();


            ////префикс – 978 – GS1 префикс за ISBN,
            ////регистрационна група – идентифицира определена страна, географски регион или езикова област; определя се от Международната агенция за ISBN; на България са присъдени регистрационни групи 978-954 и 978-619,
            ////регистрант – идентифицира конкретен издател; с различна дължина е в зависимост от обема на продукцията на издателя; присъжда се от Националната агенция за ISBN в съответствие с областите (диапазоните), определени от Международната агенция за ISBN; за България издателите могат да получат 2, 3, 4 и 5-цифров индивидуален код. Определен е и общ (споделен) код 978 - 954 - 799 и 978 - 619 - 188,
            ////издание – идентифицира конкретен формат или издание на дадена монографична публикация. (пример: 978 - 619 - XXXX - 25),
            ////контролна цифра – предназначена е да валидира номера (пример: 978 - 619 - XXXX - 25 - 0


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

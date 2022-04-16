namespace BookStore.Services.Data.Book
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    using BookStore.Data;
    using BookStore.Data.Models;
    using BookStore.Services.Mapping;
    using BookStore.Web.ViewModels.Books;
    using BookStore.Web.ViewModels.Home;

    public class BooksService : IBooksService
    {
        private readonly ApplicationDbContext db;

        public BooksService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateBook(CreateBookModel model)
        {
            //var userId = this.httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value 
            //   == null ? "1ae93590-714e-488f-aef6-622473947f4b" : this.httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var categoryId = this.db.Categories
                .Where(c => c.Type == model.Type)
                .Select(c => c.Id)
                .FirstOrDefault();

            var image = new Image
            {
                ImageUrl = model.ImageURl,
                Extension = Path.GetExtension(model.ImageURl),
                CreatedByUserId = "1ae93590-714e-488f-aef6-622473947f4b",
            };

            this.db.Images.Add(image);

            var isb = model.ISBN.Split("-").ToArray();

            //ISBN 978 - 954 - 27 - 2741 - 5
            var newIsbn = new InternationalStandardBookNumber
            {
                Prefix = isb[0],
                RegistrationGroup = isb[1],
                Registrant = isb[2],
                Edition = isb[3],
                CheckDigit = isb[4],
                IsStillOnNationalAgency = true,
            };

            this.db.InternationalStandardBookNumbers.Add(newIsbn);

            var book = new Book
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                Quantity = model.Quantity,
                Price = model.Price,
                Pages = model.Pages,
                Cover = model.Cover,
                Language = model.Language,
                Year = model.Year,
                DateOfPublication = model.DateOfPublication,
                UniqueIdBook = model.IdOfBook,
                ISBN = model.ISBN,
                IsOnPromotional = false,
                ImageId = image.Id,
                CreatedByUserId = "1ae93590-714e-488f-aef6-622473947f4b",
                CategoryId = categoryId,
            };

            this.db.Books.Add(book);

            //////префикс – 978 – GS1 префикс за ISBN,
            //////регистрационна група – идентифицира определена страна, географски регион или езикова област; определя се от Международната агенция за ISBN; на България са присъдени регистрационни групи 978-954 и 978-619,
            //////регистрант – идентифицира конкретен издател; с различна дължина е в зависимост от обема на продукцията на издателя; присъжда се от Националната агенция за ISBN в съответствие с областите (диапазоните), определени от Международната агенция за ISBN; за България издателите могат да получат 2, 3, 4 и 5-цифров индивидуален код. Определен е и общ (споделен) код 978 - 954 - 799 и 978 - 619 - 188,
            //////издание – идентифицира конкретен формат или издание на дадена монографична публикация. (пример: 978 - 619 - XXXX - 25),
            //////контролна цифра – предназначена е да валидира номера (пример: 978 - 619 - XXXX - 25 - 0

            this.db.SaveChanges();
        }

        public IEnumerable<BookInListModel> GetAll(int page, string sort, int itemsPerPage = 4)
        {
            ;
            var book = this.db.Books
                  .Select(x => new BookInListModel
                  {
                      Price = x.Price.ToString(),
                      Author = x.Author,
                      Title = x.Title,
                      CreatedOn = DateTime.Now,
                      Sort = sort,
                      ImageUrl = this.db.Images.Where(i => i.Id == x.ImageId).Select(x => x.ImageUrl).FirstOrDefault(),
                      Id = x.Id,
                  })
                  .Skip((page - 1) * itemsPerPage)
                  .Take(itemsPerPage)
                  .ToList();
 
            if (sort == "Price")
            {
                book = book.OrderByDescending(x => x.Price).ToList();
            }
            if (sort == "Name")
            {
                book = book.OrderBy(x => x.Title).ToList();
            }
            else
            {
                book = book.OrderBy(x => x.CreatedOn).ToList();
            }

            return book;
        }

        public IEnumerable<BookInListModel> GetAllPromotional(int page, int itemsPerPage = 4)
        {
            var book = this.db.Books
                  .Where(x => x.IsOnPromotional == true)
                  .Select(x => new BookInListModel
                  {
                      Price = x.Price.ToString(),
                      PromoPrice = x.PromoPrice.ToString(),
                      Author = x.Author,
                      Title = x.Title,
                      ImageUrl = this.db.Images.Where(i => i.Id == x.ImageId).Select(x => x.ImageUrl).FirstOrDefault(),
                      Id = x.Id,
                  })
                  .Skip((page - 1) * itemsPerPage)
                  .Take(itemsPerPage)
                  .ToList();

            ;

            return book;
        }

        public List<BookViewModel> GetAll()
        {
            var book = this.db.Books
                .Where(x => x.IsDeleted == false)
                    .Select(x => new BookViewModel
                    {
                        Price = x.Price.ToString(),
                        Author = x.Author,
                        Title = x.Title,
                        ImageUrl = this.db.Images.Where(i => i.Id == x.ImageId).Select(x => x.ImageUrl).FirstOrDefault(),
                        Id = x.Id,
                    }).ToList();

            return book;
        }

        //public List<BookViewModel> GetPromotionalBooks()
        //{
        //    var book = this.db.Books
        //            .Select(x => new BookViewModel
        //            {
        //                Price = x.Price.ToString(),
        //                PromoPrice = x.PromoPrice.ToString(),
        //                Author = x.Author,
        //                Title = x.Title,
        //                ImageUrl = this.db.Images.Where(i => i.Id == x.ImageId).Select(x => x.ImageUrl).FirstOrDefault(),
        //                Id = x.Id,
        //                IsOnPromotional = x.IsOnPromotional,
        //            })
        //            //.Where(x => x.IsOnPromotional == true)
        //            .ToList();
        //    ;
        //    return book;
        //}

        public int GetCount()
        {
            return this.db.Books.Count();
        }

        public bool EnoughQuantity(int bookId, int orderQuantity)
        {
            var book = this.db.Books.FirstOrDefault(x => x.Id == bookId);
            if (orderQuantity <= 0)
            {
                return false;
            }

            if (book.Quantity >= orderQuantity)
            {
                book.Quantity -= orderQuantity;
                this.db.SaveChanges();

                return true;
            }

            return false;
        }

        public int GetPromotionalBooksCount()
        {
            return this.db.Books.Where(x => x.IsOnPromotional == true).Count();
        }

        public SingleBookViewModel GetById(int id)
        {
            return this.db.Books
                .Where(x => x.Id == id)
                .To<SingleBookViewModel>()
                .FirstOrDefault();
        }

        public BuyViewModel Buy(int id)
        {
            return this.db.Books
                .Where(x => x.Id == id)
                .To<BuyViewModel>()
                .FirstOrDefault();
        }

        public List<IndexPageBookViewModel> GetRandomBook()
        {
            return this.db.Books
                .OrderBy(x => Guid.NewGuid())
                .To<IndexPageBookViewModel>()
                .Take(8)
                .ToList();
        }

        public List<EveryMonthBooksViewModel> GetMonthBok()
        {
            var books = this.db.Books
            .To<EveryMonthBooksViewModel>()
            .ToList();

            var booksInCurrentMonth = new List<EveryMonthBooksViewModel>();
            var currentfullMonthName = DateTime.Now.ToString("MMMM", CultureInfo.InvariantCulture);

            foreach (var book in books)
            {
                var date = book.CreatedOn;
                DateTime datevalue = Convert.ToDateTime(date.ToString());
                string currentMonth = datevalue.ToString("MMMM", CultureInfo.CreateSpecificCulture("us"));

                if (currentMonth == currentfullMonthName)
                {
                    booksInCurrentMonth.Add(book);
                }
            }

            return booksInCurrentMonth;
        }
    }
}

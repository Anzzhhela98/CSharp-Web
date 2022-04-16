namespace BookStore.Services.Data.Tests
{
    using System.Linq;

    using BookStore.Data;
    using BookStore.Services.Data.Book;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class BookServiceTest
    {
        [Fact]
        public void GetCountReturnsZero()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("GetCountReturnsZero").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new BooksService(dbContext);

            var result = service.GetCount();
            Assert.Equal(result, service.GetCount());
        }

        [Fact]
        public void GetCountReturnsOne()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("GetCountReturnsOne").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new BooksService(dbContext);

            service.CreateBook(new Web.ViewModels.Books.CreateBookModel
            {
                Title = "Втората България",
                Author = "Милена Димитрова",
                Description = "Над два милиона българи се откъснаха от корените си след 1989 г. В тази книга се разкриват 50 лични истории – накъде тръгнаха хората, какъв е животът им. Анализирани са и приликите с миграцията от нашите земи към Украйна, Аржентина, Щатите преди повече от век. И още – за икономическия смисъл и как се променя идентичността на сънародниците ни по света.",
                Quantity = 100,
                Price = 18.00M,
                Pages = 324,
                Cover = "мека",
                Language = "български",
                Year = 2019,
                DateOfPublication = "7.02.2022 г.",
                IdOfBook = "83744",
                ISBN = "978-619-1952-45-8",
                ImageURl = "9a706910-5f62-4fc5-b954-32fd0c3c8bd9",
                Type = "Love",
                CategoryId = 32,
            });
            var result = service.GetCount();
            Assert.Equal(result, service.GetCount());
        }

        [Fact]
        public void GetCountReturnsMoreThanOne()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("GetCountReturnsMoreThanOne").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new BooksService(dbContext);

            for (int i = 0; i < 3; i++)
            {
                service.CreateBook(new Web.ViewModels.Books.CreateBookModel
                {
                    Title = "Втората България",
                    Author = "Милена Димитрова",
                    Description = "Над два милиона българи се откъснаха от корените си след 1989 г. В тази книга се разкриват 50 лични истории – накъде тръгнаха хората, какъв е животът им. Анализирани са и приликите с миграцията от нашите земи към Украйна, Аржентина, Щатите преди повече от век. И още – за икономическия смисъл и как се променя идентичността на сънародниците ни по света.",
                    Quantity = 100,
                    Price = 18.00M,
                    Pages = 324,
                    Cover = "мека",
                    Language = "български",
                    Year = 2019,
                    DateOfPublication = "7.02.2022 г.",
                    IdOfBook = "83744",
                    ISBN = "978-619-1952-45-8",
                    ImageURl = "9a706910-5f62-4fc5-b954-32fd0c3c8bd9",
                    Type = "Love",
                    CategoryId = 32,
                });

                dbContext.SaveChanges();
            }

            dbContext.SaveChanges();

            Assert.Equal(3, service.GetCount());
        }

        [Fact]
        public void AddBookWorkCorrec()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("AddBookWorkCorrec").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new BooksService(dbContext);

            service.CreateBook(new Web.ViewModels.Books.CreateBookModel
            {
                Title = "Втората България",
                Author = "Милена Димитрова",
                Description = "Над два милиона българи се откъснаха от корените си след 1989 г. В тази книга се разкриват 50 лични истории – накъде тръгнаха хората, какъв е животът им. Анализирани са и приликите с миграцията от нашите земи към Украйна, Аржентина, Щатите преди повече от век. И още – за икономическия смисъл и как се променя идентичността на сънародниците ни по света.",
                Quantity = 100,
                Price = 18.00M,
                Pages = 324,
                Cover = "мека",
                Language = "български",
                Year = 2019,
                DateOfPublication = "7.02.2022 г.",
                IdOfBook = "83744",
                ISBN = "978-619-1952-45-8",
                ImageURl = "9a706910-5f62-4fc5-b954-32fd0c3c8bd9",
                Type = "Love",
                CategoryId = 32,
            });

            var book = dbContext.Books.FirstOrDefaultAsync(x => x.Title == "Втората България");
            Assert.Equal("Втората България", book.Result.Title);
        }

        [Fact]
        public void GetAllReturnsCollection()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("GetAllReturnsCollection").Options;
            var dbContext1 = new ApplicationDbContext(options);
            var service = new BooksService(dbContext1);

            service.CreateBook(new Web.ViewModels.Books.CreateBookModel
            {
                Title = "Втората България",
                Author = "Милена Димитрова",
                Description = "Над два милиона българи се откъснаха от корените си след 1989 г. В тази книга се разкриват 50 лични истории – накъде тръгнаха хората, какъв е животът им. Анализирани са и приликите с миграцията от нашите земи към Украйна, Аржентина, Щатите преди повече от век. И още – за икономическия смисъл и как се променя идентичността на сънародниците ни по света.",
                Quantity = 100,
                Price = 18.00M,
                Pages = 324,
                Cover = "мека",
                Language = "български",
                Year = 2019,
                DateOfPublication = "7.02.2022 г.",
                IdOfBook = "83744",
                ISBN = "978-619-1952-45-8",
                ImageURl = "9a706910-5f62-4fc5-b954-32fd0c3c8bd9",
                Type = "Love",
                CategoryId = 32,
            });
            dbContext1.SaveChanges();

            var books = service.GetAll();

            Assert.Single(books);
        }

        [Fact]
        public void GetAllReturnsOneBook()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("GetAllReturnsOneBook").Options;
            var dbContext1 = new ApplicationDbContext(options);
            var service = new BooksService(dbContext1);

            service.CreateBook(new Web.ViewModels.Books.CreateBookModel
            {
                Title = "Втората България",
                Author = "Милена Димитрова",
                Description = "Над два милиона българи се откъснаха от корените си след 1989 г. В тази книга се разкриват 50 лични истории – накъде тръгнаха хората, какъв е животът им. Анализирани са и приликите с миграцията от нашите земи към Украйна, Аржентина, Щатите преди повече от век. И още – за икономическия смисъл и как се променя идентичността на сънародниците ни по света.",
                Quantity = 100,
                Price = 18.00M,
                Pages = 324,
                Cover = "мека",
                Language = "български",
                Year = 2019,
                DateOfPublication = "7.02.2022 г.",
                IdOfBook = "83744",
                ISBN = "978-619-1952-45-8",
                ImageURl = "9a706910-5f62-4fc5-b954-32fd0c3c8bd9",
                Type = "Love",
                CategoryId = 32,
            });
            dbContext1.SaveChanges();

            var books = service.GetAll();

            Assert.Single(books);
        }

        [Fact]
        public void GetAllReturnsSpecificBook()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("GetAllReturnsSpecificBook").Options;
            var dbContext1 = new ApplicationDbContext(options);
            var service = new BooksService(dbContext1);

            service.CreateBook(new Web.ViewModels.Books.CreateBookModel
            {
                Title = "Втората България",
                Author = "Милена Димитрова",
                Description = "Над два милиона българи се откъснаха от корените си след 1989 г. В тази книга се разкриват 50 лични истории – накъде тръгнаха хората, какъв е животът им. Анализирани са и приликите с миграцията от нашите земи към Украйна, Аржентина, Щатите преди повече от век. И още – за икономическия смисъл и как се променя идентичността на сънародниците ни по света.",
                Quantity = 100,
                Price = 18.00M,
                Pages = 324,
                Cover = "мека",
                Language = "български",
                Year = 2019,
                DateOfPublication = "7.02.2022 г.",
                IdOfBook = "83744",
                ISBN = "978-619-1952-45-8",
                ImageURl = "9a706910-5f62-4fc5-b954-32fd0c3c8bd9",
                Type = "Love",
                CategoryId = 32,
            });
            dbContext1.SaveChanges();

            var books = service.GetAll();
            var book = books[0];

            Assert.Equal("Втората България", book.Title);
        }

        [Fact]
        public void GetAllReturnsNullWhenItemsPerPageAreMoreThanBookInDb()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("GetAllReturnsNullWhenItemsPerPageAreMoreThanBookInDb").Options;
            var dbContext1 = new ApplicationDbContext(options);
            var service = new BooksService(dbContext1);

            service.CreateBook(new Web.ViewModels.Books.CreateBookModel
            {
                Title = "Втората България",
                Author = "Милена Димитрова",
                Description = "Над два милиона българи се откъснаха от корените си след 1989 г. В тази книга се разкриват 50 лични истории – накъде тръгнаха хората, какъв е животът им. Анализирани са и приликите с миграцията от нашите земи към Украйна, Аржентина, Щатите преди повече от век. И още – за икономическия смисъл и как се променя идентичността на сънародниците ни по света.",
                Quantity = 100,
                Price = 18.00M,
                Pages = 324,
                Cover = "мека",
                Language = "български",
                Year = 2019,
                DateOfPublication = "7.02.2022 г.",
                IdOfBook = "83744",
                ISBN = "978-619-1952-45-8",
                ImageURl = "9a706910-5f62-4fc5-b954-32fd0c3c8bd9",
                Type = "Love",
                CategoryId = 32,
            });
            dbContext1.SaveChanges();

            var books = service.GetAll(3,100);

            Assert.Empty(books);
        }

        [Fact]
        public void GetAllReturnsEmptyWhenPageAreMore()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("GetAllReturnsEmptyWhenPageAreMore").Options;
            var dbContext1 = new ApplicationDbContext(options);
            var service = new BooksService(dbContext1);

            service.CreateBook(new Web.ViewModels.Books.CreateBookModel
            {
                Title = "Втората България",
                Author = "Милена Димитрова",
                Description = "Над два милиона българи се откъснаха от корените си след 1989 г. В тази книга се разкриват 50 лични истории – накъде тръгнаха хората, какъв е животът им. Анализирани са и приликите с миграцията от нашите земи към Украйна, Аржентина, Щатите преди повече от век. И още – за икономическия смисъл и как се променя идентичността на сънародниците ни по света.",
                Quantity = 100,
                Price = 18.00M,
                Pages = 324,
                Cover = "мека",
                Language = "български",
                Year = 2019,
                DateOfPublication = "7.02.2022 г.",
                IdOfBook = "83744",
                ISBN = "978-619-1952-45-8",
                ImageURl = "9a706910-5f62-4fc5-b954-32fd0c3c8bd9",
                Type = "Love",
                CategoryId = 32,
            });
            dbContext1.SaveChanges();

            var books = service.GetAll(300, 4);

            Assert.Empty(books);
        }

        [Fact]
        public void GetAllReturnsSingleBook()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("GetAllReturnsSingleBook").Options;
            var dbContext1 = new ApplicationDbContext(options);
            var service = new BooksService(dbContext1);

            service.CreateBook(new Web.ViewModels.Books.CreateBookModel
            {
                Title = "Втората България",
                Author = "Милена Димитрова",
                Description = "Над два милиона българи се откъснаха от корените си след 1989 г. В тази книга се разкриват 50 лични истории – накъде тръгнаха хората, какъв е животът им. Анализирани са и приликите с миграцията от нашите земи към Украйна, Аржентина, Щатите преди повече от век. И още – за икономическия смисъл и как се променя идентичността на сънародниците ни по света.",
                Quantity = 100,
                Price = 18.00M,
                Pages = 324,
                Cover = "мека",
                Language = "български",
                Year = 2019,
                DateOfPublication = "7.02.2022 г.",
                IdOfBook = "83744",
                ISBN = "978-619-1952-45-8",
                ImageURl = "9a706910-5f62-4fc5-b954-32fd0c3c8bd9",
                Type = "Love",
                CategoryId = 32,
            });
            dbContext1.SaveChanges();

            var books = service.GetAll(1, 4);

            Assert.Single(books);
        }

        [Fact]
        public void GetAllPromotionalReturnsEmptyBook()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("GetAllPromotionalReturnsSingleBook").Options;
            var dbContext1 = new ApplicationDbContext(options);
            var service = new BooksService(dbContext1);

            service.CreateBook(new Web.ViewModels.Books.CreateBookModel
            {
                Title = "Втората България",
                Author = "Милена Димитрова",
                Description = "Над два милиона българи се откъснаха от корените си след 1989 г. В тази книга се разкриват 50 лични истории – накъде тръгнаха хората, какъв е животът им. Анализирани са и приликите с миграцията от нашите земи към Украйна, Аржентина, Щатите преди повече от век. И още – за икономическия смисъл и как се променя идентичността на сънародниците ни по света.",
                Quantity = 100,
                Price = 18.00M,
                Pages = 324,
                Cover = "мека",
                Language = "български",
                Year = 2019,
                DateOfPublication = "7.02.2022 г.",
                IdOfBook = "83744",
                ISBN = "978-619-1952-45-8",
                ImageURl = "9a706910-5f62-4fc5-b954-32fd0c3c8bd9",
                Type = "Love",
                CategoryId = 32,
            });
            dbContext1.SaveChanges();

            var books = service.GetAllPromotional(1, 4);

            Assert.Empty(books);
        }

        [Fact]
        public void GetAllPromotionalReturnsCollectionOfBooksOnPromotional()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("GetAllPromotionalReturnsCollectionOfBooksOnPromotional").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new BooksService(dbContext);

            service.CreateBook(new Web.ViewModels.Books.CreateBookModel
            {
                Title = "Втората България",
                Author = "Милена Димитрова",
                Description = "Над два милиона българи се откъснаха от корените си след 1989 г. В тази книга се разкриват 50 лични истории – накъде тръгнаха хората, какъв е животът им. Анализирани са и приликите с миграцията от нашите земи към Украйна, Аржентина, Щатите преди повече от век. И още – за икономическия смисъл и как се променя идентичността на сънародниците ни по света.",
                Quantity = 100,
                Price = 18.00M,
                Pages = 324,
                Cover = "мека",
                Language = "български",
                Year = 2019,
                DateOfPublication = "7.02.2022 г.",
                IdOfBook = "83744",
                ISBN = "978-619-1952-45-8",
                ImageURl = "9a706910-5f62-4fc5-b954-32fd0c3c8bd9",
                Type = "Love",
                CategoryId = 32,
            });

            var books = service.GetAllPromotional(1);

            var oneBook = books.Where(x => x.IsOnPromotional == true);

            Assert.True(oneBook.All(oneBook => oneBook.IsOnPromotional == true));
        }

        [Fact]
        public void GetPromotionalBooksCountReturnsOne()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("GetPromotionalBooksCountReturnsOne").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new BooksService(dbContext);

            service.CreateBook(new Web.ViewModels.Books.CreateBookModel
            {
                Title = "Втората България",
                Author = "Милена Димитрова",
                Description = "Над два милиона българи се откъснаха от корените си след 1989 г. В тази книга се разкриват 50 лични истории – накъде тръгнаха хората, какъв е животът им. Анализирани са и приликите с миграцията от нашите земи към Украйна, Аржентина, Щатите преди повече от век. И още – за икономическия смисъл и как се променя идентичността на сънародниците ни по света.",
                Quantity = 100,
                Price = 18.00M,
                Pages = 324,
                Cover = "мека",
                Language = "български",
                Year = 2019,
                DateOfPublication = "7.02.2022 г.",
                IdOfBook = "83744",
                ISBN = "978-619-1952-45-8",
                ImageURl = "9a706910-5f62-4fc5-b954-32fd0c3c8bd9",
                Type = "Love",
                CategoryId = 32,
            });
            var books = service.GetPromotionalBooksCount();

            Assert.Equal(1, books);
        }

        [Fact]
        public void GetPromotionalBooksCountReturnZero()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("GetPromotionalBooksCountReturnZero").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new BooksService(dbContext);

            var books = service.GetPromotionalBooksCount();
            dbContext.SaveChanges();

            Assert.Equal(0, books);
        }

        [Fact]
        public void GetPromotionalBooksCountReturnMoreThanOne()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("GetPromotionalBooksCountReturnMoreThanOne").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new BooksService(dbContext);

            service.CreateBook(new Web.ViewModels.Books.CreateBookModel
            {
                Title = "Втората България",
                Author = "Милена Димитрова",
                Description = "Над два милиона българи се откъснаха от корените си след 1989 г. В тази книга се разкриват 50 лични истории – накъде тръгнаха хората, какъв е животът им. Анализирани са и приликите с миграцията от нашите земи към Украйна, Аржентина, Щатите преди повече от век. И още – за икономическия смисъл и как се променя идентичността на сънародниците ни по света.",
                Quantity = 100,
                Price = 18.00M,
                Pages = 324,
                Cover = "мека",
                Language = "български",
                Year = 2019,
                DateOfPublication = "7.02.2022 г.",
                IdOfBook = "83744",
                ISBN = "978-619-1952-45-8",
                ImageURl = "9a706910-5f62-4fc5-b954-32fd0c3c8bd9",
                Type = "Love",
                CategoryId = 32,
            });
            service.CreateBook(new Web.ViewModels.Books.CreateBookModel
            {
                Title = "Втората България",
                Author = "Милена Димитрова",
                Description = "Над два милиона българи се откъснаха от корените си след 1989 г. В тази книга се разкриват 50 лични истории – накъде тръгнаха хората, какъв е животът им. Анализирани са и приликите с миграцията от нашите земи към Украйна, Аржентина, Щатите преди повече от век. И още – за икономическия смисъл и как се променя идентичността на сънародниците ни по света.",
                Quantity = 100,
                Price = 18.00M,
                Pages = 324,
                Cover = "мека",
                Language = "български",
                Year = 2019,
                DateOfPublication = "7.02.2022 г.",
                IdOfBook = "83744",
                ISBN = "978-619-1952-45-8",
                ImageURl = "9a706910-5f62-4fc5-b954-32fd0c3c8bd9",
                Type = "Love",
                CategoryId = 32,
            });

            var books = service.GetPromotionalBooksCount();

            Assert.Equal(2, books);
        }

        [Fact]
        public void EnoughQuantityReturnTrue()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("EnoughQuantityReturnTrue").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new BooksService(dbContext);

            service.CreateBook(new Web.ViewModels.Books.CreateBookModel
            {
                Title = "Втората България",
                Author = "Милена Димитрова",
                Description = "Над два милиона българи се откъснаха от корените си след 1989 г. В тази книга се разкриват 50 лични истории – накъде тръгнаха хората, какъв е животът им. Анализирани са и приликите с миграцията от нашите земи към Украйна, Аржентина, Щатите преди повече от век. И още – за икономическия смисъл и как се променя идентичността на сънародниците ни по света.",
                Quantity = 100,
                Price = 18.00M,
                Pages = 324,
                Cover = "мека",
                Language = "български",
                Year = 2019,
                DateOfPublication = "7.02.2022 г.",
                IdOfBook = "83744",
                ISBN = "978-619-1952-45-8",
                ImageURl = "9a706910-5f62-4fc5-b954-32fd0c3c8bd9",
                Type = "Love",
                CategoryId = 32,
            });
            dbContext.SaveChanges();

            var result = service.EnoughQuantity(1, 100);

            Assert.True(result);
        }

        [Fact]
        public void EnoughQuantityReturnFalse()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("EnoughQuantityReturnFalse").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new BooksService(dbContext);

            service.CreateBook(new Web.ViewModels.Books.CreateBookModel
            {
                Title = "Втората България",
                Author = "Милена Димитрова",
                Description = "Над два милиона българи се откъснаха от корените си след 1989 г. В тази книга се разкриват 50 лични истории – накъде тръгнаха хората, какъв е животът им. Анализирани са и приликите с миграцията от нашите земи към Украйна, Аржентина, Щатите преди повече от век. И още – за икономическия смисъл и как се променя идентичността на сънародниците ни по света.",
                Quantity = 100,
                Price = 18.00M,
                Pages = 324,
                Cover = "мека",
                Language = "български",
                Year = 2019,
                DateOfPublication = "7.02.2022 г.",
                IdOfBook = "83744",
                ISBN = "978-619-1952-45-8",
                ImageURl = "9a706910-5f62-4fc5-b954-32fd0c3c8bd9",
                Type = "Love",
                CategoryId = 32,
            });
            dbContext.SaveChanges();

            var result = service.EnoughQuantity(1, 300);

            Assert.False(result);
        }

        [Fact]
        public void EnoughQuantityReturnFalseWhenQuantityIsLessThanZero()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("EnoughQuantityReturnFalseWhenQuantityIsLessThanZero").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new BooksService(dbContext);

            service.CreateBook(new Web.ViewModels.Books.CreateBookModel
            {
                Title = "Втората България",
                Author = "Милена Димитрова",
                Description = "Над два милиона българи се откъснаха от корените си след 1989 г. В тази книга се разкриват 50 лични истории – накъде тръгнаха хората, какъв е животът им. Анализирани са и приликите с миграцията от нашите земи към Украйна, Аржентина, Щатите преди повече от век. И още – за икономическия смисъл и как се променя идентичността на сънародниците ни по света.",
                Quantity = 100,
                Price = 18.00M,
                Pages = 324,
                Cover = "мека",
                Language = "български",
                Year = 2019,
                DateOfPublication = "7.02.2022 г.",
                IdOfBook = "83744",
                ISBN = "978-619-1952-45-8",
                ImageURl = "9a706910-5f62-4fc5-b954-32fd0c3c8bd9",
                Type = "Love",
                CategoryId = 32,
            });
            dbContext.SaveChanges();

            var result = service.EnoughQuantity(1, -199);

            Assert.False(result);
        }

        [Fact]
        public void EnoughQuantityReturnFalseWhenQuantityIsEaqualToZero()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("EnoughQuantityReturnFalseWhenQuantityIsLessThanZero").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new BooksService(dbContext);

            service.CreateBook(new Web.ViewModels.Books.CreateBookModel
            {
                Title = "Втората България",
                Author = "Милена Димитрова",
                Description = "Над два милиона българи се откъснаха от корените си след 1989 г. В тази книга се разкриват 50 лични истории – накъде тръгнаха хората, какъв е животът им. Анализирани са и приликите с миграцията от нашите земи към Украйна, Аржентина, Щатите преди повече от век. И още – за икономическия смисъл и как се променя идентичността на сънародниците ни по света.",
                Quantity = 100,
                Price = 18.00M,
                Pages = 324,
                Cover = "мека",
                Language = "български",
                Year = 2019,
                DateOfPublication = "7.02.2022 г.",
                IdOfBook = "83744",
                ISBN = "978-619-1952-45-8",
                ImageURl = "9a706910-5f62-4fc5-b954-32fd0c3c8bd9",
                Type = "Love",
                CategoryId = 32,
            });
            dbContext.SaveChanges();

            var result = service.EnoughQuantity(1, 0);

            Assert.False(result);
        }
    }
}

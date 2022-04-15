namespace BookStore.Services.Data.Tests
{
    using System.Linq;

    using BookStore.Data;
    using BookStore.Services.Data.Author;
    using BookStore.Web.ViewModels.Author;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class AuthorTests
    {
        [Fact]
        public void AddAuthorInSystemCreateNewAuthor()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("AddAuthorInSystemCreateNewAuthor").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new AuthorService(dbContext);

            var author = new RegistarAuthorModel
            {
                Name = "NewAuthor",
                Registrant = "Tim",
            };

            service.AddAuthorInSystem(author, "1ae93590-714e-488f-aef6-622473947f4b");

            var result = dbContext.SystemAuthors.Count();
            Assert.Equal(1, result);
        }

        [Fact]
        public void AddAuthorInSystemGetCurrentAuhtor()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("AddAuthorInSystemGetCurrentAuhtor").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new AuthorService(dbContext);

            var author = new RegistarAuthorModel
            {
                Name = "NewAuthor",
                Registrant = "Tim",
            };

            service.AddAuthorInSystem(author, "1ae93590-714e-488f-aef6-622473947f4b");

            var name = dbContext.SystemAuthors.Any(x => x.Name == "NewAuthor");

            Assert.True(name);
        }

        [Fact]
        public void IsAuthorizedToCreateBookReturnTrue()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("IsAuthorizedToCreateBookReturnTrue").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new AuthorService(dbContext);

            var author = new RegistarAuthorModel
            {
                Name = "NewAuthor",
                Registrant = "Tim",
            };

            service.AddAuthorInSystem(author, "1ae93590-714e-488f-aef6-622473947f4b");
            var result = service.IsAuthorizedToCreateBook("1ae93590-714e-488f-aef6-622473947f4b");

            Assert.True(result);
        }

        [Fact]
        public void IsAuthorizedToCreateBookReturnFalse()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("IsAuthorizedToCreateBookReturnFalse").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new AuthorService(dbContext);

            var author = new RegistarAuthorModel
            {
                Name = "NewAuthor",
                Registrant = "Tim",
            };

            service.AddAuthorInSystem(author, "1ae93590-714e-488f-aef6-622473947f4b");
            var result = service.IsAuthorizedToCreateBook("1ae93590-714e-488f-aef6-6224721212121");

            Assert.False(result);
        }

        [Fact]
        public void IsAuthorizedToCreateBookReturnFalseWhenRegistrantIsNull()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("IsAuthorizedToCreateBookReturnFalseWhenRegistrantIsNull").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new AuthorService(dbContext);

            var author = new RegistarAuthorModel
            {
                Name = "NewAuthor",
                Registrant = null,
            };

            service.AddAuthorInSystem(author, "1ae93590-714e-488f-aef6-622473947f4b");
            var result = service.IsAuthorizedToCreateBook("1ae93590-714e-488f-aef6-622473947f4b");
            Assert.False(result);
        }

        [Fact]
        public void IsAuthorizedToCreateBookReturnFalseWhenUserIsNotInTheDb()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("IsAuthorizedToCreateBookReturnFalseWhenUserIsNotInTheDb").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new AuthorService(dbContext);

            var author = new RegistarAuthorModel
            {
                Name = "NewAuthor",
                Registrant = "Tim",
            };

            service.AddAuthorInSystem(author, "1ae93590-714e-488f-aef6-622473947f4b");
            var result = service.IsAuthorizedToCreateBook(null);
            Assert.False(result);
        }

        [Fact]
        public void IsAuthorizedToCreateBookReturnFalseWhenRegistrantAndUserAreNotCorrect()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("IsAuthorizedToCreateBookReturnFalseWhenRegistrantAndUserAreNotCorrect").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new AuthorService(dbContext);

            var author = new RegistarAuthorModel
            {
                Name = "NewAuthor",
                Registrant = null,
            };

            service.AddAuthorInSystem(author, "1ae93590-714e-488f-aef6-62247394ddddd7f4b");
            var result = service.IsAuthorizedToCreateBook(null);
            Assert.False(result);
        }
    }
}

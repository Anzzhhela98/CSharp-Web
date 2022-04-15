namespace BookStore.Services.Data.Tests
{
    using BookStore.Data;
    using BookStore.Services.Data.Contact;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class ContactServiceTests
    {
        [Fact]
        public void GetUserEmailReturnNull()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("GetUserEmailReturnNull").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new ContactsService(dbContext);

            var result = service.GetUserEmail("testOne");
            Assert.Null(result);
        }

        [Fact]
        public void GetUserEmailReturnCorrectUser()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("GetUserEmailReturnCorrectUser").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new ContactsService(dbContext);

            dbContext.Users.Add(new BookStore.Data.Models.ApplicationUser { Id = "test" });
            dbContext.SaveChanges();
            var result = service.GetUserEmail("test");

            Assert.NotNull(result);
        }

        [Fact]
        public void GetUserEmailReturnOneUser()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("GetUserEmailReturnOneUser").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new ContactsService(dbContext);

            dbContext.Users.Add(new BookStore.Data.Models.ApplicationUser { Id = "test", Email = "rado43@" });
            dbContext.SaveChanges();
            var result = service.GetUserEmail("test");

            Assert.Equal("rado43@", result.Email);
        }
    }
}

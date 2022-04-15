namespace BookStore.Services.Data.Tests
{
    using System.Linq;

    using BookStore.Data;
    using BookStore.Services.Data.Order;
    using BookStore.Web.ViewModels.Payment;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class OrderTests
    {
        [Fact]
        public void SetOrderShouldSetCorrectCount()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("SetOrderShouldSetCorrectCount").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new OrdersService(dbContext);

            var order = new PaymentFromViewModel
            {
                FullName = "TestName",
                City = "Plovdiv",
                Address = "SomeAddress",
                Number = "22222",
                Count = 23,
            };

            service.SetOrder(order, "aprove", "someUserId");
            var result = dbContext.Orders.Count();

            Assert.Equal(1, result);
        }

        [Fact]
        public void SetOrderShouldReturnCurrentOrder()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("SetOrderShouldReturnCurrentOrder").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new OrdersService(dbContext);

            var order = new PaymentFromViewModel
            {
                FullName = "TestName",
                City = "Plovdiv",
                Address = "SomeAddress",
                Number = "22222",
                Count = 23,
            };

            var anotherOrder = new PaymentFromViewModel
            {
                FullName = "AnotherName",
                City = "Plovdiv",
                Address = "SomeAddress",
                Number = "22222",
                Count = 23,
            };

            service.SetOrder(order, "aprove", "someUserId");
            service.SetOrder(anotherOrder, "aprove", "anotherUserId");

            var result = dbContext.Orders.FirstOrDefault(x => x.Id == 2);

            Assert.NotNull(result);
        }

        [Fact]
        public void SetOrderShouldReturnCurrentSpecificValueOfOrder()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("SetOrderShouldReturnCurrentSpecificValueOfOrder").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new OrdersService(dbContext);

            var order = new PaymentFromViewModel
            {
                FullName = "TestName",
                City = "Plovdiv",
                Address = "SomeAddress",
                Number = "22222",
                Count = 23,
            };

            var anotherOrder = new PaymentFromViewModel
            {
                FullName = "AnotherName",
                City = "Plovdiv",
                Address = "SomeAddress",
                Number = "22222",
                Count = 23,
            };

            service.SetOrder(order, "aprove", "someUserId");
            service.SetOrder(anotherOrder, "aprove", "anotherUserId");

            var result = dbContext.Orders.Where(x => x.Id == 2).Select(x => x.OrderNumber).FirstOrDefault();

            Assert.Equal("0002", result);
        }
    }
}

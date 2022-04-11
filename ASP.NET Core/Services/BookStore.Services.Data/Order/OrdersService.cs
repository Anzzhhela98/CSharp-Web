namespace BookStore.Services.Data.Order
{
    using System;
    using System.Linq;
    using System.Security.Claims;

    using BookStore.Data;
    using BookStore.Data.Models;
    using BookStore.Web.ViewModels.Payment;
    using Microsoft.AspNetCore.Http;

    public class OrdersService : IOrdersService
    {
        private readonly ApplicationDbContext db;
        private readonly IHttpContextAccessor httpContextAccessor;

        public OrdersService(ApplicationDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            this.db = db;
            this.httpContextAccessor = httpContextAccessor;
        }

        public void SetOrder(PaymentFromViewModel model, string statusPayment)
        {
            var userId = this.httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var order = new Order
            {
                StatusPayment = statusPayment,
                Status = "procesing",
                CreatedOn = DateTime.Now,
                FullName = model.FullName,
                Email = model.StripeEmail,
                City = model.City,
                Address = model.Address,
                Number = model.Number,
                Count = model.Count,
                Price = model.TotalPriceTransfer / 100,
                CreatedByUserId = userId,
                BookId = model.Id,
            };

            this.db.Orders.Add(order);
            this.db.SaveChanges();
            order.OrderNumber = "000" + order.Id;

            this.db.SaveChanges();
        }
    }
}

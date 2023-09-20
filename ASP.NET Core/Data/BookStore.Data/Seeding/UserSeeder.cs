namespace BookStore.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using BookStore.Data.Models;

    public class UserSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {

            if (dbContext.Users.Any())
            {
                return;
            }

            await dbContext.Users.AddAsync(new ApplicationUser
            {
                Id = "9bdff8c18-09bf-413a-ad80-25120fe04253",
                UserName = "https://knigomania.bg/media/catalog/product/cache/02f16ac392ba7c312a70e2f3c5d752a7/p/r/prevrashtane-sartseto-na-drakona-2-9789542621478.jpg",
                Email = "anjela98@gmail.com",
                PasswordHash = "123456",
            });
        }
    }
}

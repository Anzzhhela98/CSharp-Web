namespace BookStore.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using BookStore.Data.Models;

    public class StoreLocationSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.StoreLocations.Any())
            {
                return;
            }

            await dbContext.StoreLocations.AddAsync(new StoreLocation
            {
                Name = "Книгомания - Левски 28",
                Address = "София 1142, бул. Васил Левски 28",
                PhoneNumber = "0893 305 101",
                Email = "levski28@knigomania.bg",
                WorkingTime = "10,00 - 18,30 ч.",
                Image = "https://knigomania.bg/media/wysiwyg/Levski_________new.jpg",
            });

            await dbContext.StoreLocations.AddAsync(new StoreLocation
            {
                Name = "Книгомания - Прага 17",
                Address = "София, бул. Прага 17",
                PhoneNumber = "0893 305 102",
                Email = "praga17@knigomania.bg",
                WorkingTime = "10,00 - 18,30 ч.",
                Image = "https://knigomania.bg/media/bookstores/praga7.jpg",
            });

            await dbContext.StoreLocations.AddAsync(new StoreLocation
            {
                Name = "Ciela / Книгомания / Комсед - Mall Paradise",
                Address = "София, бул. Черни връх 100",
                PhoneNumber = "0893 305 104",
                Email = "knigomaniarai@mail.bg",
                WorkingTime = "10,00 - 22,00 ч.",
                Image = "https://knigomania.bg/media/bookstores/Paradise2.jpg",
            });

            await dbContext.SaveChangesAsync();
        }
    }
}

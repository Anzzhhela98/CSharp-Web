namespace BookStore.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using BookStore.Data.Models;

    public class BookSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Books.Any())
            {
                return;
            }

            await dbContext.Books.AddAsync(new Book
            {
                CharacteristicId = 2,
                CreatedByUserId = "7867e526-9726-4304-9ef7-56f3fe3cd782",
            });
        }
    }
}

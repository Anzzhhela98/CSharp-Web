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
                CharacteristicId = 15,
                CreatedByUserId = "7867e526-9726-4304-9ef7-56f3fe3cd782",
            });

            await dbContext.Books.AddAsync(new Book
            {
                CharacteristicId = 16,
                CreatedByUserId = "7867e526-9726-4304-9ef7-56f3fe3cd782",
            });

            await dbContext.Books.AddAsync(new Book
            {
                CharacteristicId = 17,
                CreatedByUserId = "7867e526-9726-4304-9ef7-56f3fe3cd782",
            });

            await dbContext.Books.AddAsync(new Book
            {
                CharacteristicId = 18,
                CreatedByUserId = "d157866b-1ddf-47c0-8731-daed4d8dc35e",
            });

            await dbContext.Books.AddAsync(new Book
            {
                CharacteristicId = 19,
                CreatedByUserId = "d157866b-1ddf-47c0-8731-daed4d8dc35e",
            });

            await dbContext.Books.AddAsync(new Book
            {
                CharacteristicId = 20,
                CreatedByUserId = "7867e526-9726-4304-9ef7-56f3fe3cd782",
            });

            await dbContext.Books.AddAsync(new Book
            {
                CharacteristicId = 21,
                CreatedByUserId = "7867e526-9726-4304-9ef7-56f3fe3cd782",
            });

            await dbContext.Books.AddAsync(new Book
            {
                CharacteristicId = 22,
                CreatedByUserId = "d157866b-1ddf-47c0-8731-daed4d8dc35e",
            });

            await dbContext.Books.AddAsync(new Book
            {
                CharacteristicId = 23,
                CreatedByUserId = "d157866b-1ddf-47c0-8731-daed4d8dc35e",
            });
        }
    }
}

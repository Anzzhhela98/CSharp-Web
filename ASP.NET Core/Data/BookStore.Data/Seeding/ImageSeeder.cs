namespace BookStore.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using BookStore.Data.Models;

    public class ImageSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Images.Any())
            {
                return;
            }

            await dbContext.Images.AddAsync(new Image
            {
                Id = "8b35bbea - 8fb3 - 48f7 - 8809 - 924c6b3bca49",
                ImageUrl = "https://knigomania.bg/media/catalog/product/cache/02f16ac392ba7c312a70e2f3c5d752a7/v/t/vtorata-bulgaria-9786191952458.jpg",
                Extension = "JPG",
                CreatedByUserId = "7867e526-9726-4304-9ef7-56f3fe3cd782",
            });
        }
    }
}

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

            await dbContext.Images.AddAsync(new Image
            {
                //Id = "12600584-a003-4c94-8652-58fd05d865a7",
                ImageUrl = "https://knigomania.bg/media/catalog/product/cache/02f16ac392ba7c312a70e2f3c5d752a7/p/o/ponyakoga-lazha-9789542838487.jpg",
                Extension = "JPG",
                CreatedByUserId = "7867e526-9726-4304-9ef7-56f3fe3cd782",
            });

            await dbContext.Images.AddAsync(new Image
            {
                //Id = "875bfeb6-06fb-4593-a112-2eedf4a2e528",
                ImageUrl = "https://knigomania.bg/media/catalog/product/cache/02f16ac392ba7c312a70e2f3c5d752a7/c/h/chovekat--koyto-dva-pati-umrya-9786191517817.jpg",
                Extension = "JPG",
                CreatedByUserId = "7867e526-9726-4304-9ef7-56f3fe3cd782",
            });

            await dbContext.Images.AddAsync(new Image
            {
                //Id = "1c7701ef-027a-490a-a931-cfafdbf247bd",
                ImageUrl = "https://knigomania.bg/media/catalog/product/cache/02f16ac392ba7c312a70e2f3c5d752a7/s/m/smart-v-smoking-9789543896752.jpg",
                Extension = "JPG",
                CreatedByUserId = "d157866b-1ddf-47c0-8731-daed4d8dc35e",
            });

            await dbContext.Images.AddAsync(new Image
            {
                //Id = "cc021ad7-0d27-4260-b2db-8932868fe3c9",
                ImageUrl = "https://knigomania.bg/media/catalog/product/cache/02f16ac392ba7c312a70e2f3c5d752a7/s/t/steve-jobs-9780349145082.jpg",
                Extension = "JPG",
                CreatedByUserId = "d157866b-1ddf-47c0-8731-daed4d8dc35e",
            });

            await dbContext.Images.AddAsync(new Image
            {
                //Id = "c230a0b5-c44f-41b6-bfef-954c05f22dc3",
                ImageUrl = "https://knigomania.bg/media/catalog/product/cache/02f16ac392ba7c312a70e2f3c5d752a7/n/e/negramotnoto-momiche-9786191504862.jpg",
                Extension = "JPG",
                CreatedByUserId = "d157866b-1ddf-47c0-8731-daed4d8dc35e",
            });

            await dbContext.Images.AddAsync(new Image
            {
                //Id = "d85dc17d-575d-43b4-b0b5-70d5377969ce",
                ImageUrl = "https://knigomania.bg/media/catalog/product/cache/02f16ac392ba7c312a70e2f3c5d752a7/m/o/moeto-semeistvo-i-drugi-zhivotni-9786191506842.jpg",
                Extension = "JPG",
                CreatedByUserId = "d157866b-1ddf-47c0-8731-daed4d8dc35e",
            });

            await dbContext.Images.AddAsync(new Image
            {
                //Id = "8403589d-a52a-491c-84b2-a07b49cae9ce",
                ImageUrl = "https://knigomania.bg/media/catalog/product/cache/02f16ac392ba7c312a70e2f3c5d752a7/h/a/hari-potar-i-stayata-na-tainite-603927.jpg",
                Extension = "JPG",
                CreatedByUserId = "7867e526-9726-4304-9ef7-56f3fe3cd782",
            });

            await dbContext.Images.AddAsync(new Image
            {
                //Id = "4d5167c5-7f99-4081-ba6b-148c43dd9fb7",
                ImageUrl = "https://knigomania.bg/media/catalog/product/cache/02f16ac392ba7c312a70e2f3c5d752a7/h/a/hari-potyr-i-filosofskiqt-kamyk-9789544464684.jpg",
                Extension = "JPG",
                CreatedByUserId = "7867e526-9726-4304-9ef7-56f3fe3cd782",
            });
        }
    }
}

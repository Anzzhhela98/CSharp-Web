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
                Id = "9a706910-5f62-4fc5-b954-32fd0c3c8bd9",
                ImageUrl = "https://knigomania.bg/media/catalog/product/cache/02f16ac392ba7c312a70e2f3c5d752a7/v/t/vtorata-bulgaria-9786191952458.jpg",
                Extension = "JPG",
                CreatedByUserId = "1ae93590-714e-488f-aef6-622473947f4b",
            });

            await dbContext.Images.AddAsync(new Image
            {
                Id = "875a082f-6d8a-4195-966d-34fda801fd2d",
                ImageUrl = "https://knigomania.bg/media/catalog/product/cache/02f16ac392ba7c312a70e2f3c5d752a7/p/o/ponyakoga-lazha-9789542838487.jpg",
                Extension = "JPG",
                CreatedByUserId = "560393c3-cd12-416b-b420-b07a0e074db6",
            });

            await dbContext.Images.AddAsync(new Image
            {
                Id = "7e345f0f-0c79-4ef5-8a1a-a7fc8d40052c",
                ImageUrl = "https://knigomania.bg/media/catalog/product/cache/02f16ac392ba7c312a70e2f3c5d752a7/c/h/chovekat--koyto-dva-pati-umrya-9786191517817.jpg",
                Extension = "JPG",
                CreatedByUserId = "1ae93590-714e-488f-aef6-622473947f4b",
            });

            await dbContext.Images.AddAsync(new Image
            {
                Id = "442bb5c0-c99c-440e-a191-17be24dec13b",
                ImageUrl = "https://knigomania.bg/media/catalog/product/cache/02f16ac392ba7c312a70e2f3c5d752a7/s/m/smart-v-smoking-9789543896752.jpg",
                Extension = "JPG",
                CreatedByUserId = "560393c3-cd12-416b-b420-b07a0e074db6",
            });

            await dbContext.Images.AddAsync(new Image
            {
                Id = "0c70370f-3086-4cbc-a0e8-8c8d17188f66",
                ImageUrl = "https://knigomania.bg/media/catalog/product/cache/02f16ac392ba7c312a70e2f3c5d752a7/s/t/steve-jobs-9780349145082.jpg",
                Extension = "JPG",
                CreatedByUserId = "1ae93590-714e-488f-aef6-622473947f4b",
            });

            await dbContext.Images.AddAsync(new Image
            {
                Id = "2fd355c6-a775-463e-a4ef-bc04eb70ca03",
                ImageUrl = "https://knigomania.bg/media/catalog/product/cache/02f16ac392ba7c312a70e2f3c5d752a7/n/e/negramotnoto-momiche-9786191504862.jpg",
                Extension = "JPG",
                CreatedByUserId = "560393c3-cd12-416b-b420-b07a0e074db6",
            });

            await dbContext.Images.AddAsync(new Image
            {
                Id = "9a706910-5f62-4fc5-b954-32fd0c3c8bd9",
                ImageUrl = "https://knigomania.bg/media/catalog/product/cache/02f16ac392ba7c312a70e2f3c5d752a7/m/o/moeto-semeistvo-i-drugi-zhivotni-9786191506842.jpg",
                Extension = "JPG",
                CreatedByUserId = "1ae93590-714e-488f-aef6-622473947f4b",
            });

            await dbContext.Images.AddAsync(new Image
            {
                Id = "c7eab172-83e7-459d-b2a6-005eaede0d31",
                ImageUrl = "https://knigomania.bg/media/catalog/product/cache/02f16ac392ba7c312a70e2f3c5d752a7/h/a/hari-potar-i-stayata-na-tainite-603927.jpg",
                Extension = "JPG",
                CreatedByUserId = "560393c3-cd12-416b-b420-b07a0e074db6",
            });

            await dbContext.Images.AddAsync(new Image
            {
                Id = "9d73da44-cb60-4ac4-92c0-c13fb94be2ad",
                ImageUrl = "https://knigomania.bg/media/catalog/product/cache/02f16ac392ba7c312a70e2f3c5d752a7/h/a/hari-potyr-i-filosofskiqt-kamyk-9789544464684.jpg",
                Extension = "JPG",
                CreatedByUserId = "1ae93590-714e-488f-aef6-622473947f4b",
            });
        }
    }
}

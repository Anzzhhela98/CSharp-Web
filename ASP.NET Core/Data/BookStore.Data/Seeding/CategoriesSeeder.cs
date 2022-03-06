namespace BookStore.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using BookStore.Data.Models;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            await dbContext.Categories.AddAsync(new Category { Type = "Drama" });
            await dbContext.Categories.AddAsync(new Category { Type = "Journals" });
            await dbContext.Categories.AddAsync(new Category { Type = "Biographies" });
            await dbContext.Categories.AddAsync(new Category { Type = "Science Fiction" });
            await dbContext.Categories.AddAsync(new Category { Type = "Cookbooks" });
            await dbContext.Categories.AddAsync(new Category { Type = "Action" });
            await dbContext.Categories.AddAsync(new Category { Type = "Comics" });
            await dbContext.Categories.AddAsync(new Category { Type = "Adventure" });
            await dbContext.Categories.AddAsync(new Category { Type = "Health" });
            await dbContext.Categories.AddAsync(new Category { Type = "Poetry" });
            await dbContext.Categories.AddAsync(new Category { Type = "Romance" });
            await dbContext.Categories.AddAsync(new Category { Type = "History" });
            await dbContext.Categories.AddAsync(new Category { Type = "Mystery" });
            await dbContext.Categories.AddAsync(new Category { Type = "Science" });
            await dbContext.Categories.AddAsync(new Category { Type = "Fantasy" });
            await dbContext.Categories.AddAsync(new Category { Type = "Horror" });
            await dbContext.Categories.AddAsync(new Category { Type = "Art" });
            await dbContext.Categories.AddAsync(new Category { Type = "Travel" });
            await dbContext.Categories.AddAsync(new Category { Type = "Children's" });
            await dbContext.Categories.AddAsync(new Category { Type = "World classics" });

            await dbContext.SaveChangesAsync();
        }
    }
}

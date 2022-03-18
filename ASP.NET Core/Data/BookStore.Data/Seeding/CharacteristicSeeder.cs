namespace BookStore.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using BookStore.Data.Models;

    public class CharacteristicSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Characteristics.Any())
            {
                return;
            }

            await dbContext.Characteristics.AddAsync(new Characteristic
            {
                Title = "Втората България",
                Author = "Милена Димитрова",
                Description = "Над два милиона българи се откъснаха от корените си след 1989 г. В тази книга се разкриват 50 лични истории – накъде тръгнаха хората, какъв е животът им. Анализирани са и приликите с миграцията от нашите земи към Украйна, Аржентина, Щатите преди повече от век. И още – за икономическия смисъл и как се променя идентичността на сънародниците ни по света.",
                Quantity = 100,
                Price = 18.00M,
                Pages = 324,
                Cover = "мека",
                Language = "български",
                Year = 2019,
                DateOfPublication = "7.02.2022 г.",
                UniqueIdBook = "83744",
                ISBN = "9786191952458",
                ImageId = "8b35bbea - 8fb3 - 48f7 - 8809 - 924c6b3bca49",
                IsOnPromotional = false,
            });
        }
    }
}

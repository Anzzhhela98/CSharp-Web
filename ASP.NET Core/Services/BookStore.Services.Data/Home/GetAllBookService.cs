namespace BookStore.Services.Data.Home
{
    using System.Collections.Generic;
    using System.Linq;

    using BookStore.Data;
    using BookStore.Web.ViewModels.Home;

    public class GetAllBookService : IGetAllBookService
    {
        private readonly ApplicationDbContext db;

        public GetAllBookService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<IndexViewModel> GetAll()
        {
            var book = this.db.Characteristics
                    .Select(x => new IndexViewModel
                    {
                        Price = x.Price.ToString(),
                        Author = x.Author,
                        Title = x.Title,
                        ImageUrl = this.db.Images.Where(i => i.Id == x.ImageId).Select(x => x.ImageUrl).FirstOrDefault(),
                        Id = x.Id,
                    }).ToList();

            return book;
        }
    }
}

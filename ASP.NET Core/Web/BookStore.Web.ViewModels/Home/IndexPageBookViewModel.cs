namespace BookStore.Web.ViewModels.Home
{
    using BookStore.Data.Models;
    using BookStore.Services.Mapping;

    public class IndexPageBookViewModel : IMapFrom<Book>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public string ImageImageUrl { get; set; }

        public string Price { get; set; }
    }
}

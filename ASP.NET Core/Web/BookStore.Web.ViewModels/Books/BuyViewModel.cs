namespace BookStore.Web.ViewModels.Books
{
    using BookStore.Data.Models;
    using BookStore.Services.Mapping;

    public class BuyViewModel : IMapFrom<Book>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageImageUrl { get; set; }

        public string Price { get; set; }

        public string Author { get; set; }

        public int Pages { get; set; }

        public string Language { get; set; }
    }
}

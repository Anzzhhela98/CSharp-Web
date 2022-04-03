namespace BookStore.Web.ViewModels.Books
{
    using BookStore.Data.Models;
    using BookStore.Services.Mapping;

    public class SingleBookViewModel : IMapFrom<Book>
    {
        public int Id { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Price { get; set; }

        public string ImageImageUrl { get; set; }

        public bool IsOnPromotional { get; set; }

        public string CategoryType { get; set; }

        public int Pages { get; set; }

        public string Cover { get; set; }

        public string Language { get; set; }

        public int Year { get; set; }

        public int Quantity { get; set; }

        public string DateOfPublication { get; set; }

        public string ISBN { get; set; }

        public string Description { get; set; }

        public string UniqueIdBook { get; set; }
    }
}

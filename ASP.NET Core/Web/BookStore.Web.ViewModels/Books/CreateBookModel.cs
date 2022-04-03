namespace BookStore.Web.ViewModels.Books
{
    public class CreateBookModel
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public int Pages { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public string Cover { get; set; }

        public string Language { get; set; }

        public int Year { get; set; }

        public string DateOfPublication { get; set; }

        public string IdOfBook { get; set; }

        public string ISBN { get; set; }

        public int CategoryId { get; set; }

        public string ImageURl { get; set; }
    }
}

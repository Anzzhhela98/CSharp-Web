namespace BookStore.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class BookCategories
    {
        public int BookId { get; set; }

        public Book Book { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}

namespace BookStore.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        public ICollection<BookCategories> BookCategories { get; set; } = new HashSet<BookCategories>();
    }
}

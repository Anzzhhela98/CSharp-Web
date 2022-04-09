namespace BookStore.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using BookStore.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        [Required]
        public string Type { get; set; }

        public ICollection<Book> Books { get; set; }
            = new HashSet<Book>();
    }
}

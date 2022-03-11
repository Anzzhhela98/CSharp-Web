namespace BookStore.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        public int Id { get; set; }

        [Required]
        public int CharacteristicId { get; set; }

        public virtual Characteristic Characteristic { get; set; }

        [Required]
        public string CreatedByUserId { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }

        public ICollection<BookCategories> BookCategories { get; set; } = new HashSet<BookCategories>();
    }
}

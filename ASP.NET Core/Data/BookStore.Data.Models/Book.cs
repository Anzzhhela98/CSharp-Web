namespace BookStore.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using BookStore.Data.Common.Models;

    public class Book : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [MaxLength(50)]
        public string Author { get; set; }

        [Required]
        [MaxLength(400)]
        public string Description { get; set; }

        [Required]
        [Range(1, 200)]
        public int Quantity { get; set; }

        [Range(0.50, 100)]
        public decimal Price { get; set; }

        [Required]
        public int CharacteristicId { get; set; }

        public virtual Characteristic Characteristic { get; set; }

        public ICollection<Category> Categories { get; set; } = new HashSet<Category>();

        ////public int CategoryId { get; set; }

        ////public virtual Category Category { get; set; }

        [Required]
        public string CreatedByUserId { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }
    }
}

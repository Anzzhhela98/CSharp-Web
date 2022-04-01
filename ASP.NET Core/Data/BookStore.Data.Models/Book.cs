namespace BookStore.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(50)]
        public string Author { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [Range(1, 200)]
        public int Quantity { get; set; }

        [Range(0.50, 100)]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(3000)]
        public int Pages { get; set; }

        [Required]
        [MaxLength(20)]
        public string Cover { get; set; }

        [Required]
        [MaxLength(30)]
        public string Language { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string DateOfPublication { get; set; }

        [Required]
        [MaxLength(10)]
        public string UniqueIdBook { get; set; }

        [Required]
        [MinLength(18)]
        [MaxLength(18)]
        public string ISBN { get; set; }

        public bool IsOnPromotional { get; set; }

        public string ImageId { get; set; }

        public Image Image { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [Required]
        public string CreatedByUserId { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }
    }
}

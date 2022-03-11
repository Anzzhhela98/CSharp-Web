namespace BookStore.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Characteristic
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
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
        [MaxLength(6)]
        public string UniqueIdBook { get; set; }

        [Required]
        [MinLength(14)]
        [MaxLength(14)]
        public string ISBN { get; set; }

        public string ImageId { get; set; }

        public Image Image { get; set; }
    }
}

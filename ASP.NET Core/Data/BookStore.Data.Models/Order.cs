namespace BookStore.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using BookStore.Data.Common.Models;

    public class Order
    {
        public int Id { get; init; }

        public string OrderNumber { get; set; }

        [Required]
        [Range(1, 100)]
        public int Count { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        public string Number { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string StatusPayment { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string CreatedByUserId { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }

        [Required]
        public int BookId { get; set; }

        public Book Book { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}

namespace BookStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class StoreLocation
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string WorkingTime { get; set; }

        [Required]
        public string Image { get; set; }
    }
}

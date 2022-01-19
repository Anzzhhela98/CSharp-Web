namespace CarShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;
    public class User
    {
        [MaxLength(IdMaxLenght)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(DefaultMaxLenght)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsMechanic { get; set; }

        // • Has an Id – a string, Primary Key
        //•	Has a Username – a string with min length 4 and max length 20 (required)
        //•	Has an Email - a string (required)
        //•	Has a Password – a string with min length 5 and max length 20  - hashed in the database(required)
        //•	Has а IsMechanic – a bool indicating if the user is a mechanic or a client
    }
}

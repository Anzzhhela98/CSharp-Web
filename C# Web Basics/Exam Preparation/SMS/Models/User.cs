namespace SMS.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;

    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(MaxUserLength)]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string CartId { get; set; }

        public Cart Cart { get; set; }
    }
}

//•	Has an Id – a string, Primary Key
//•	Has a Username – a string with min length 5 and max length 20 (required)
//•	Has an Email – a string, which holds only valid email (required) on validator.cs
//•	Has a Password – a string with min length 6 and max length 20 - hashed in the database (required) hash in controller 
//•	Has a Cart – a Cart object (required)


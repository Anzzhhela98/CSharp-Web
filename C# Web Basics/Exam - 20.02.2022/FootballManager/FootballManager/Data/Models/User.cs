namespace FootballManager.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(MaxUserLength)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(MaxUserEmail)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<UserPalyer> UserPlayers { get; set; } = new HashSet<UserPalyer>();
    }
}
//•	Has an Id – a string, Primary Key
//•	Has a Username – a string with min length 5 and max length 20 (required)
//•	Has an Email – a string with min length 10 and max length 60 (required)
//•	Has a Password – a string with min length 5 and max length 20 (before hashed)  -no max length required for a hashed password in the database (required)
//•	Has UserPlayers collection



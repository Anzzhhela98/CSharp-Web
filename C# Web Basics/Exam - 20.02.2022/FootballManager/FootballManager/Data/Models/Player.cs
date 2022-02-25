namespace FootballManager.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;

    public class Player
    {
        public int  Id { get; set; }

        [Required]
        [MaxLength(MaxPalyerFullNameLength)]
        public string FullName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(MaxPalyerPositionLength)]
        public string Position { get; set; }

        [Required]
        [MaxLength(MaxPalyerSpeedLength)]
        public byte Speed { get; set; }

        [Required]
        [MaxLength(MaxPalyerEnduranceLength)]
        public byte Endurance { get; set; }

        [Required]
        [MaxLength(MaxPalyerDescriptionLength)]
        public string Description { get; set; }

        public ICollection<UserPalyer> UserPlayers { get; set; } = new HashSet<UserPalyer>();
    }
}

//•	Has Id – an int, Primary Key
//•	Has FullName – a string (required); min.length: 5, max.length: 80
//•	Has ImageUrl – a string (required)
//•	Has Position – a string (required); min.length: 5, max.length: 20
//•	Has Speed – a byte (required); cannot be negative or bigger than 10
//•	Has Endurance – a byte (required); cannot be negative or bigger than 10
//•	Has a Description – a string with max length 200 (required)
//•	Has UserPlayers collection

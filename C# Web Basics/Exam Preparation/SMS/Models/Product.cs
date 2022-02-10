namespace SMS.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;
    public class Product
    {
        public string Id { get; set; } =  Guid.NewGuid().ToString();

        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [Range(0.05, 1000)]
        public decimal Price { get; set; }

        public string CartId { get; set; }

        public Cart Cart { get; set; }
    }
}

//•	Has an Id – a string, Primary Key
//•	Has a Name – a string with min length 4 and max length 20 (required)
//•	Has Price – a decimal (in range 0.05 – 1000)
//•	Has a Cart – a Cart object

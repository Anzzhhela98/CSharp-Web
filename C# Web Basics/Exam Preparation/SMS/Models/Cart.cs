namespace SMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Cart
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string UserId { get; set; }

        [Required]
        public User User { get; set; }

        public IEnumerable<Product> Products { get; set; } = new HashSet<Product>();
    }
}
//•	Has an Id – a string, Primary Key
//•	Has User – a User object (required)
//•	Has Products – a collection of Products 


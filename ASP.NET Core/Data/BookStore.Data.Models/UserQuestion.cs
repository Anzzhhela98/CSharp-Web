namespace BookStore.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using BookStore.Data.Common.Models;

    public class UserQuestion : BaseDeletableModel<int>
    {
        [Required]
        public string Question { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile no. is required")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [MinLength(4)]
        public string OrderNumber { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}

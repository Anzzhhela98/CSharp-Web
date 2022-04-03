namespace BookStore.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using BookStore.Data.Common.Models;

    public class UserQuestion : IAuditInfo
    {
        public int Id { get; init; }

        [Required]
        public string Question { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        public string OrderNumber { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}

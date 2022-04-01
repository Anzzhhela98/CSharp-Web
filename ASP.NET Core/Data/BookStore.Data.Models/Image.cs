namespace BookStore.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using BookStore.Data.Common.Models;

    public class Image : BaseModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Extension { get; set; }

        [Required]
        public string CreatedByUserId { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }
    }
}

namespace BookStore.Web.ViewModels.Contact
{
    using System.ComponentModel.DataAnnotations;

    using BookStore.Data.Models;
    using BookStore.Services.Mapping;

    public class ContactsViewModel : IMapFrom<UserQuestion>, IMapTo<UserQuestion>
    {
        [Required]
        public string Question { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        public string OrderNumber { get; set; }
    }
}

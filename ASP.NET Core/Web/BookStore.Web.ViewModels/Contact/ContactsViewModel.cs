namespace BookStore.Web.ViewModels.Contact
{
    using System.ComponentModel.DataAnnotations;

    public class ContactsViewModel
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

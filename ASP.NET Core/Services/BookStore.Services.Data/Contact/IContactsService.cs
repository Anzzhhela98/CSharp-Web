namespace BookStore.Services.Data.Contact
{
    using BookStore.Web.ViewModels.Contact;

    public interface IContactsService
    {
        RegisteredUserViewModel GetUserEmail(string userId);

        public void SetUserMessage(ContactsViewModel model);
    }
}

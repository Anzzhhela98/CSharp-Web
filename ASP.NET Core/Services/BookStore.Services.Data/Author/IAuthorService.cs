namespace BookStore.Services.Data.Book
{
    using BookStore.Web.ViewModels.Author;

    public interface IAuthorService
    {
        public bool IsAuthorizedToCreateBook(string userId);

        public void AddAuthorInSystem(RegistarAuthorModel model, string userId);
    }
}

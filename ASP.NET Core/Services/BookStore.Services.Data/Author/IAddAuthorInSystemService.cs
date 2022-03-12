namespace BookStore.Services.Data.Author
{
    using BookStore.Web.ViewModels.Author;

    public interface IAddAuthorInSystemService
    {
        public void AddAuthorInSystem(RegistarAuthorModel model);
    }
}

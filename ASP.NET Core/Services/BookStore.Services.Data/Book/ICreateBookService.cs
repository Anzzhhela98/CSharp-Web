namespace BookStore.Services.Data.Book
{
    using BookStore.Web.ViewModels.Book;

    public interface ICreateBookService
    {
        public void CreateBook(CreateBookModel model);
    }
}

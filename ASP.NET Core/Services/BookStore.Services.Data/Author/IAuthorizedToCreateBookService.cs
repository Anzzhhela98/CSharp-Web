namespace BookStore.Services.Data.Book
{
    public interface IAuthorizedToCreateBookService
    {
        public bool IsAuthorizedToCreateBook(string userId);
    }
}

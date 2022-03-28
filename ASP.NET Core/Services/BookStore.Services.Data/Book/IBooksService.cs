namespace BookStore.Services.Data.Book
{
    using System.Collections.Generic;

    using BookStore.Web.ViewModels.Book;

    public interface IBooksService
    {
        IEnumerable<BookInListModel> GetAll(int page, int itemsPerPage = 4);
        int GetCount();
    }
}

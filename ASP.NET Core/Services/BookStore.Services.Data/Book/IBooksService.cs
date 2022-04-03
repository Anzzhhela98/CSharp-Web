namespace BookStore.Services.Data.Book
{
    using System.Collections.Generic;

    using BookStore.Web.ViewModels.Books;
    using BookStore.Web.ViewModels.Home;

    public interface IBooksService
    {
        IEnumerable<BookInListModel> GetAll(int page, int itemsPerPage = 4);

        IEnumerable<BookInListModel> GetAllPromotional(int page, int itemsPerPage = 4);

        int GetCount();

        int GetPromotionalBooksCount();

        public void CreateBook(CreateBookModel model);

        List<BookViewModel> GetAll();

        List<BookViewModel> GetPromotionalBooks();

        SingleBookViewModel GetById(int id);
    }
}

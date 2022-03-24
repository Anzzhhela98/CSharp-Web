namespace BookStore.Services.Data.Home
{
    using System.Collections.Generic;

    using BookStore.Web.ViewModels.Home;

    public interface IGetBookService
    {
        List<IndexViewModel> GetAll();

        List<IndexViewModel> GetPromotionalBooks();
    }
}

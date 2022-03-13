namespace BookStore.Services.Data.Home
{
    using System.Collections.Generic;

    using BookStore.Web.ViewModels.Home;

    public interface IGetAllBookService
    {
        List<IndexViewModel> GetAll();
    }
}

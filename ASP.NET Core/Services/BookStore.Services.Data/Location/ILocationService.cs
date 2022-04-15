namespace BookStore.Services.Data.Location
{
    using System.Collections.Generic;

    using BookStore.Web.ViewModels.Location;

    public interface ILocationService
    {
        List<LocationViewModel> AllLocation();

        LocationByIdViewModel LocationById(int id);
    }
}

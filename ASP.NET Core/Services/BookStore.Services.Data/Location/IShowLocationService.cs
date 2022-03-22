namespace BookStore.Services.Data.Location
{
    using System.Collections.Generic;

    using BookStore.Web.ViewModels.Location;

    public interface IShowLocationService
    {
       List<LocationViewModel> AllLocation();
    }
}

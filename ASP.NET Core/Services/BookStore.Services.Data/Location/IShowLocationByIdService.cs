namespace BookStore.Services.Data.Location
{
    using BookStore.Web.ViewModels.Location;

    public interface IShowLocationByIdService
    {
        LocationByIdViewModel LocationById(int id);
    }
}

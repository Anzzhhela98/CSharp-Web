namespace SharedTrip.Services
{
    using SharedTrip.ViewModel;
    using System.Collections.Generic;

    public interface IValidator
    {
        ICollection<string> IsValidRegister(UserRegisterForm model);

        ICollection<string> IsValidLogin(bool isUserInTheDb);

        ICollection<string> IsValidTripFormModel(TripsAddFormModel model);
    }
}

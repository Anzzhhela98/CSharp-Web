namespace CarShop.Services
{
    using CarShop.Models.Cars;
    using CarShop.Models.Users;

    public interface IValidator
    {
        ICollection<string> IsValidRegister(RegisterUserFormModel model);

        ICollection<string> IsValidLogIn(bool isUserInTheDb);

        ICollection<string> IsValidFomCar(AddCarFormModel modelCar);
    }
}

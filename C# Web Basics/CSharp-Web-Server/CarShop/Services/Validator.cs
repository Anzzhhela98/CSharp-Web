namespace CarShop.Services
{
    using CarShop.Models.Cars;
    using CarShop.Models.Users;
    using System.Text.RegularExpressions;
    using static Data.DataConstants;
    public class Validator : IValidator
    {
        public ICollection<string> IsValidRegister(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            if (model.UserName.Length < UserMinUserName || model.UserName.Length > DefaultMaxLenght)
            {
                 errors.Add($"Username must be between {UserMinUserName} and {DefaultMaxLenght} characters long!");
            }
            if (!Regex.IsMatch(model.Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                errors.Add($"Email is not a valid email address!");
            }
            if (model.Password.Length < UserMinPassword || model.Password.Length > DefaultMaxLenght)
            {
                errors.Add($"Password must be between {UserMinPassword} and {DefaultMaxLenght} characters long!");
            }
            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"Passwords must be eaqul!");
            }
            if (model.UserType != UserTypeMechanic && model.UserType != UserTypeClient)
            {
                errors.Add($"UserType must be {UserTypeMechanic} or {UserTypeClient}");
            }

            return errors;
        }

        public ICollection<string> IsValidLogIn(bool isUserInTheDb)
        {
            var errors = new List<string>();

            if (!isUserInTheDb)
            {
                errors.Add("Wrong Password or Username!");
                errors.Add("User does not exist!");
            }

            return errors;
        }

        public ICollection<string> IsValidFomCar(AddCarFormModel model)
        {
            var errors = new List<string>();

            if (model.Model.Length < carModelMinLength || model.Model.Length > DefaultMaxLenght)
            {
                errors.Add($"Model {model.Model} must be between {carModelMinLength} and {DefaultMaxLenght}");
            }
            if (!Uri.IsWellFormedUriString(model.Image, UriKind.Absolute))
            {
                errors.Add($"Image {model.Image} is not a valid url!");
            }
            if (model.Year < minYear || model.Year > maxYear)
            {
                errors.Add($"Year must be between {minYear} and {maxYear}!");
            }
            if (!Regex.IsMatch(model.PlateNumber, carPlateNumberRegularExpression))
            {
                errors.Add($"Plate Number is invalid!");
            }

            return errors;
        }
    }
}
//•	Has a PlateNumber – a string – Must be a valid Plate number (2 Capital English letters, followed by 4 digits, followed by 2 Capital English letters (required)

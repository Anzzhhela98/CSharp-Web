namespace SMS.Services
{
    using SMS.ViewModels.Products;
    using SMS.ViewModels.Users;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using static Data.DataConstants;

    public class Validator : IValidator
    {
        public ICollection<string> IsValidRegister(UserRegisterForm model)
        {
            var errors = new List<string>();

            if (model.UserName.Length < MinUsernameLength || model.UserName.Length > MaxNameLength)
            {
                errors.Add($"Username must be between {MinUsernameLength} and {MaxNameLength} characters long!");
            }
            if (!Regex.IsMatch(model.Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                errors.Add($"Email is not a valid email address!");
            }
            if (model.Password.Length < MinUserPasswordLength || model.Password.Length > MaxUserLength)
            {
                errors.Add($"Password must be between {MinUserPasswordLength} and {MaxUserLength} characters long!");
            }
            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"Passwords must be eaqul!");
            }

            return errors;
        }

        public ICollection<string> IsValidLogin(bool isUserInTheDb)
        {
            var errors = new List<string>();

            if (!isUserInTheDb)
            {
                errors.Add("Wrong Password or Username!");
                errors.Add("User does not exist!");
            }

            return errors;
        }

        public ICollection<string> IsValidFormProduct(CreateProductForm model)
        {
            var errors = new List<string>();

            if (model.Name.Length < MinNameLength || model.Name.Length > MaxNameLength)
            {
                errors.Add($"Product {model.Name} is not in the correct format!");
                errors.Add($"Must be bewtween {MinNameLength} and {MaxNameLength}.");
            }
            if (model.Price < MinPrice || model.Price > MaxPrice)
            {
                errors.Add($"Price must be bewtween {MinPrice} and {MaxPrice}.");
            }

            return errors;
        }
    }
}

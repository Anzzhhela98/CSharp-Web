namespace FootballManager.Services
{
    using FootballManager.ViewModels.Palyers;
    using FootballManager.ViewModels.User;
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using static Data.DataConstants;

    internal class Validator : IValidator
    {
        public ICollection<string> IsEmailExist(bool isEmailInTheDb)
        {
            var errors = new List<string>();

            if (isEmailInTheDb)
            {
                errors.Add("User with that Email address alredy exists!");
            }

            return errors;
        }

        public ICollection<string> IsValidAddPlayerFormModel(AddPlayerFormModel model)
        {
            var errors = new List<string>();

            if (model.FullName.Length < MinPalyerFullNameLength || model.FullName.Length > MaxPalyerFullNameLength)
            {
                errors.Add($"FullName must be between {MinPalyerFullNameLength} and {MaxPalyerFullNameLength}!");
            }
            if (model.Position.Length < MinPalyerPositionLength || model.FullName.Length > MaxPalyerPositionLength)
            {
                errors.Add($"Position must be between {MinPalyerPositionLength} and {MaxPalyerPositionLength}!");
            }
            if (model.Speed < MinPalyerSpeedLength || model.Speed > MaxPalyerSpeedLength)
            {
                errors.Add($"Speed must be between {MinPalyerSpeedLength} and {MaxPalyerSpeedLength}!");
            }
            if (model.Endurance < MinPalyerEnduranceLength || model.Endurance > MaxPalyerEnduranceLength)
            {
                errors.Add($"Endurance must be between {MinPalyerEnduranceLength} and {MaxPalyerEnduranceLength}!");
            }
            if (model.Description.Length > MaxPalyerDescriptionLength )
            {
                errors.Add($"Description maximum length is {MaxPalyerDescriptionLength}!");
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

        public ICollection<string> IsValidRegister(UserRegisterFormModel model)
        {
            var errors = new List<string>();

            if (model.UserName.Length < MinUsernameLength || model.UserName.Length > MaxUserLength)
            {
                errors.Add($"Username must be between {MinUsernameLength} and {MaxUserLength} characters long!");
            }
            if (!Regex.IsMatch(model.Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                errors.Add($"Email is not a valid email address!");
            }
            if (model.Email.Length < MinUserEmail || model.Email.Length > MaxUserEmail)
            {
                errors.Add($"Email must be between {MinUserEmail} and {MaxUserEmail}!");
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
    }
}
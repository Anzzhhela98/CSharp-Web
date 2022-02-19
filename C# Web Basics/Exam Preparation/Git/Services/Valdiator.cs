namespace Git.Services
{
    using Git.ViewModels;
    using System.Text.RegularExpressions;
    using static Data.DataConstants;

    public class Valdiator : IValidator
    {
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

        public ICollection<string> IsEmailExist(bool isEmailInTheDb)
        {
            var errors = new List<string>();

            if (isEmailInTheDb)
            {
                errors.Add("User with that Email address alredy exists!");
            }

            return errors;
        }

        public ICollection<string> IsValidRegister(UserRegisterForm model)
        {
            var errors = new List<string>();

            if (model.UserName.Length < MinUserNameLength || model.UserName.Length > MaxUserNameLength)
            {
                errors.Add($"Username must be between {MinUserNameLength} and {MaxUserNameLength} characters long!");
            }
            if (!Regex.IsMatch(model.Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                errors.Add($"Email is not a valid email address!");
            }
            if (model.Password.Length < MinUserPasswordLength || model.Password.Length > MaxUserPasswordLength)
            {
                errors.Add($"Password must be between {MinUserPasswordLength} and {MaxUserPasswordLength} characters long!");
            }
            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"Passwords must be eaqul!");
            }

            return errors;
        }

        public ICollection<string> IsValidCreateRepositoryFormModel(CreateRepositoryModelForm model)
        {
            var errors = new List<string>();

            if (model.Name.Length < MinRepoNameLength || model.Name.Length > MaxRepoNameLength)
            {
                errors.Add($"Name bust be between {MinRepoNameLength} and {MaxRepoNameLength} legth long!");
            }

            return errors;
        }

        public ICollection<string> IsValidCreateCommitFormModel(CreateCommitModelForm model)
        {
            var errors = new List<string>();

            if (model.Description.Length < MinCommitDescriptionLength)
            {
                errors.Add($"Description minimum length must be {MinCommitDescriptionLength}!");
            }

            return errors;
        }
    }
}

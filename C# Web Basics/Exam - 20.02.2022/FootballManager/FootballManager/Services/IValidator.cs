using FootballManager.ViewModels.Palyers;
using FootballManager.ViewModels.User;
using System.Collections.Generic;

namespace FootballManager.Services
{
    public interface IValidator
    {
        ICollection<string> IsValidRegister(UserRegisterFormModel model);

        ICollection<string> IsValidLogin(bool isUserInTheDb);

        ICollection<string> IsEmailExist(bool isUserRegistered);

        ICollection<string> IsValidAddPlayerFormModel(AddPlayerFormModel model);

        //ICollection<string> IsValidCreateCommitFormModel(CreateCommitModelForm model);

    }
}

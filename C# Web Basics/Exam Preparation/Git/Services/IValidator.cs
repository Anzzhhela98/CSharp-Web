namespace Git.Services
{
    using Git.ViewModels;

    public interface IValidator
    {
        ICollection<string> IsValidRegister(UserRegisterForm model);

        ICollection<string> IsValidLogin(bool isUserInTheDb);

        ICollection<string> IsEmailExist(bool isUserRegistered);

        ICollection<string> IsValidCreateRepositoryFormModel(CreateRepositoryModelForm model);

        ICollection<string> IsValidCreateCommitFormModel(CreateCommitModelForm model);
    }
}

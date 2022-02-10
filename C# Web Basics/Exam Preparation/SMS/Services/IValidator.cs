namespace SMS.Services
{
    using SMS.ViewModels.Products;
    using SMS.ViewModels.Users;
    using System.Collections.Generic;

    public interface IValidator
    {
        ICollection<string> IsValidRegister(UserRegisterForm model);

        ICollection<string> IsValidLogin(bool isUserInTheDb);

        ICollection<string> IsValidFormProduct(CreateProductForm model);
    }
}

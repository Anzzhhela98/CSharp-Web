namespace CarShop.Controllers
{
    using CarShop.Data;
    using CarShop.Data.Models;
    using CarShop.Models.Users;
    using CarShop.Services;
    using MyWebServer.Http;
    using MyWebServer.Controllers;
    using static Data.DataConstants;

    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly IPasswordHasher passwordHasher;
        private readonly CarShopDbContext data;

        public UsersController(
            IValidator validator,
            IPasswordHasher passwordHasher,
            CarShopDbContext data)
        {
            this.validator = validator;
            this.passwordHasher = passwordHasher;
            this.data = data;
        }

        public HttpResponse Register() => View();

        [HttpPost]
        public HttpResponse Register(RegisterUserFormModel model)
        {
            var modelErrors = this.validator.IsValidRegister(model);

            if (this.data.Users.Any(u => u.Username == model.UserName))
            {
                modelErrors.Add($"Username {model.UserName} alredy exists.");
            }

            if (modelErrors.Any())
            {
                return View("./Shared/Error", modelErrors);
            }

            var user = new User
            {
                Username = model.UserName,
                Email = model.Email,
                Password = passwordHasher.Hash(model.Password),
                IsMechanic = model.UserType == UserTypeMechanic
            };

            data.Users.Add(user);
            data.SaveChanges();

            return Redirect("/Users/Login");
        }

        public HttpResponse Login() => View();

        [HttpPost]
        public HttpResponse Login(LoginUserModel model)
        {
            var hashedPassword =  this.passwordHasher.Hash(model.Password);

            var userId = this.data.Users
                .Where(u => u.Username == model.UserName && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();

            var modelErrors = this.validator.IsValidLogIn(userId != null);

            if (userId == null) return View("./Shared/Error", modelErrors); 

            this.SignIn(userId);
            return Redirect("/Cars/All");
        }

        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }
    } 
}

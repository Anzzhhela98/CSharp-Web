namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Data;
    using SMS.Models;
    using SMS.Services;
    using SMS.ViewModels.Users;
    using System.Linq;

    public class UsersController : Controller
    {
        public readonly IValidator validator;
        public readonly SMSDbContext data;
        public readonly IPasswordHasher passwordHasher;

        public UsersController(
            IValidator validator,
            SMSDbContext data, IPasswordHasher passwordHasher = null)
        {
            this.validator = validator;
            this.data = data;
            this.passwordHasher = passwordHasher;
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(UserRegisterForm model)
        {
            var modelErrors = this.validator.IsValidRegister(model);

            if (this.data.Users.Any(x => x.UserName == model.UserName))
            {
                modelErrors.Add($"Username {model.UserName} alredy exists.");
            }

            if (modelErrors.Any())
            {
                return View("/Error", modelErrors);
            }

            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                Password = this.passwordHasher.Hash(model.Password)
            };

            var cart = new Cart
            {
                UserId = user.Id
            };

            user.Cart = cart;

            this.data.Users.Add(user);
            this.data.Carts.Add(cart);

            this.data.SaveChanges();

            return this.View("/Users/Login");
        }

        public HttpResponse Login()
        {
            return this.View();
        }


        [HttpPost]
        public HttpResponse Login(UserLoginForm model)
        {
            var userId = this.data.Users
                .Where(x => x.UserName == model.UserName && this.passwordHasher.Hash(model.Password) == x.Password)
                .Select(x => x.Id)
                .FirstOrDefault();

            var modelErrors = this.validator.IsValidLogin(userId != null);

            if (modelErrors.Any())
            {
                return View("/Error", modelErrors);
            }

            this.SignIn(userId);
            return Redirect("/");
        }

        public HttpResponse LogOut()
        {
            this.SignOut();

            return Redirect("/");
        }
    }
}

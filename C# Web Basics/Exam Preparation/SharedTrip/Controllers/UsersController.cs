namespace SharedTrip.Controllers
{
    using MyWebServer.Http;
    using SharedTrip.ViewModel;
    using MyWebServer.Controllers;
    using SharedTrip.Data;
    using SharedTrip.Services;
    using System.Linq;
    using SharedTrip.Models;

    public class UsersController : Controller
    {
        public readonly ApplicationDbContext data;
        public readonly IValidator validator;
        public readonly IPasswordHasher passwordHasher;

        public UsersController(ApplicationDbContext data, IValidator validator, IPasswordHasher passwordHasher)
        {
            this.data = data;
            this.validator = validator;
            this.passwordHasher = passwordHasher;
        }

        public HttpResponse Login() => this.View();

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
            return Redirect("/Trips/All");
        }

        public HttpResponse Register() => this.View();

        [HttpPost]
        public HttpResponse Register(UserRegisterForm model)
        {
            var modelErrors = this.validator.IsValidRegister(model);
            var existingEmail = this.data.Users
                    .Where(u => u.Email == model.Email)
                    .FirstOrDefault() != null ? true : false;

            if (existingEmail)
            {
                modelErrors.Add($"User with the same email address alredy exist!");
            }

            if (modelErrors.Any())
            {
                return View("/Error", modelErrors);
            }

            var user = new User
            {
                UserName = model.UserName,
                Password = this.passwordHasher.Hash(model.Password),
                Email = model.Email,
            };

            this.data.Users.Add(user);
            this.data.SaveChanges();

            return Redirect("/Users/Login");
        }

        public HttpResponse LogOut()
        {
            this.SignOut();

            return Redirect("/");
        }
    }
}

namespace SMS
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using SMS.Data;
    using SMS.Services;

    public class StartUp
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                    .Add<IViewEngine, CompilationViewEngine>()
                    .Add<SMSDbContext>()
                    .Add<IValidator, Validator>()
                    .Add<IPasswordHasher, PasswordHasher>())
                .WithConfiguration<SMSDbContext>(context => context
                    .Database.Migrate())
                .Start();
    }
}
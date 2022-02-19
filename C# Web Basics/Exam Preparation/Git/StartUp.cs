namespace Git
{
    using Git.Data;
    using MyWebServer;
    using System.Threading.Tasks;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using Microsoft.EntityFrameworkCore;
    using Git.Services;

    public class Startup
    {
        public static async Task Main()
               => await HttpServer
                   .WithRoutes(routes => routes
                       .MapStaticFiles()
                       .MapControllers())
                   .WithServices(services => services
                       .Add<IViewEngine, CompilationViewEngine>()
                       .Add<ApplicationDbContext>()
                       .Add<IValidator, Valdiator>()
                       .Add<IPasswordHasher, PasswordHasher>())
                   .WithConfiguration<ApplicationDbContext>(context => context
                       .Database.Migrate())
                   .Start();
    }
}

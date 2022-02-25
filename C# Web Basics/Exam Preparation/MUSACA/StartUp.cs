namespace MUSACA
{
    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using System.Threading.Tasks;

    public class Startup
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                    .Add<IViewEngine, CompilationViewEngine>())
                    //.Add<SMSDbContext>()
                    //.Add<IValidator, Validator>()
                    //.Add<IPasswordHasher, PasswordHasher>())
                //.WithConfiguration<SMSDbContext>(context => context
                //    .Database.Migrate())
                .Start();
    }
}

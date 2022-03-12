namespace BookStore.Services.Data.Author
{
    using System.Security.Claims;

    using BookStore.Data;
    using BookStore.Data.Models;
    using BookStore.Web.ViewModels.Author;
    using Microsoft.AspNetCore.Http;

    public class AddAuthorInSystemService : IAddAuthorInSystemService
    {
        private readonly ApplicationDbContext db;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AddAuthorInSystemService(ApplicationDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            this.db = db;
            this.httpContextAccessor = httpContextAccessor;
        }

        public void AddAuthorInSystem(RegistarAuthorModel model)
        {
            var userId = this.httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var author = new SystemAuthor
            {
                Name = model.Name,
                Registrant = model.Registrant,
                CreatedByUserId = userId,
            };

            this.db.SystemAuthors.Add(author);
            this.db.SaveChanges();
        }
    }
}

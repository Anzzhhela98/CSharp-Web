namespace BookStore.Data.Seeding
{
    using Microsoft.AspNetCore.Identity;

    public class MyIdentityDataSeeder
    {
        public static void SeedData(UserManager<IdentityUser> userManager)
        {
            SeedUsers(userManager);
        }

        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByNameAsync("Anzhela").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "Anzhela";
                user.Email = "anjela98@gmailcom";
                user.EmailConfirmed = true;
                user.AccessFailedCount = 3;
                user.Id = "9bdff8c18-09bf-413a-ad80-25120fe04253";
                user.PhoneNumberConfirmed = false;
                user.TwoFactorEnabled = false;
                user.LockoutEnabled = true;

                IdentityResult result = userManager.CreateAsync(user, "adm1nPassWorD*_").Result;

            }
        }
    }
}

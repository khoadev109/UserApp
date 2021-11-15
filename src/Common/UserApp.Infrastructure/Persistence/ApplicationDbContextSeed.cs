using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UserApp.Infrastructure.Identity;

namespace UserApp.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager)
        {
            if (!await userManager.Users.AnyAsync())
            {
                IdentityResult result = await userManager.CreateAsync(
                    new ApplicationUser
                    {
                        UserName = "khoa",
                        Email = "khoa@test.com"
                    },
                    "P@ssw0rd");

                if (!result.Succeeded)
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        var errorHere = $"{error.Description} { error.Code}";
                    }
                }
            }
        }
    }
}

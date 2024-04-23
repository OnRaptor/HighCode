using HighCode.Presentation.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace HighCode.Presentation.Utils
{
    public class SeedBaseData
    {
        public static async void InitSystem(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            if (!await roleManager.RoleExistsAsync("Moderator"))
                await roleManager.CreateAsync(new IdentityRole("Moderator"));
            if (!await roleManager.RoleExistsAsync("User"))
                await roleManager.CreateAsync(new IdentityRole("User"));

            //var a = await userManager.FindByNameAsync("Admin");
            //await userManager.DeleteAsync(await userManager.FindByNameAsync("Admin"));

            if (userManager.Users.Any(user => user.Email == "admin@mail.ru")) return;
            
            var user = new User() { 
                UserName = "admin",
                Email="admin@mail.ru"
            };
            if ((await userManager.CreateAsync(user, "Root_0")).Succeeded)
                await userManager.AddToRoleAsync(user, "Admin");
        }
    }
}

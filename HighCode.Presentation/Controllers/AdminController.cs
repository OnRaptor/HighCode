using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HighCode.Presentation.Controllers
{
    public class AdminController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AdminController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ChangeRole(int role)
        {
            await _userManager.AddToRoleAsync(
                await _userManager.FindByEmailAsync(User.Identity.Name),
                role == 0 ? "User" : "Moderator"
                );

            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            await _signInManager.SignInAsync(await _userManager.FindByEmailAsync(User.Identity.Name), false);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ResetRoles()
        {
            await _userManager.RemoveFromRoleAsync(
                await _userManager.FindByEmailAsync(User.Identity.Name),
                "Moderator"
                );

            await _userManager.RemoveFromRoleAsync(
                await _userManager.FindByEmailAsync(User.Identity.Name),
                "User"
                );

            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            await _signInManager.SignInAsync(await _userManager.FindByEmailAsync(User.Identity.Name), false);
            return RedirectToAction("Index");
        }
    }
}

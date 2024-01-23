using HighCode.Presentation.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HighCode.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public HomeController(
            ILogger<HomeController> logger,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager
            )
        {
            _logger = logger;
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

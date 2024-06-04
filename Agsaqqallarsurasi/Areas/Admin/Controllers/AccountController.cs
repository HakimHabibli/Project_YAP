using Agsaqqallarsurasi.Areas.Admin.ViewModels.Auth;
using Agsaqqallarsurasi.Migrations;
using Agsaqqallarsurasi.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace Agsaqqallarsurasi.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

		public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM) 
        {
            if(!ModelState.IsValid)return View(registerVM);
            AppUser newuser = new AppUser()
            {
                Fullname = registerVM.Fullname,
                UserName = registerVM.Username,
                Email = registerVM.Email,
            };
            IdentityResult registerResult = await _userManager.CreateAsync(newuser, registerVM.Password);
            if (!registerResult.Succeeded)
            {
                foreach (IdentityError error in registerResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(registerVM);
            }

            return RedirectToAction(nameof(Login));
        }

        public IActionResult Login() 
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (!ModelState.IsValid) return View(login);

            AppUser user = await _userManager.FindByEmailAsync(login.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Email or Password is wrong!");
                return View(login);
            }

            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Email or Password is wrong!");
                return View(login);
            }

            await _signInManager.SignInAsync(user, login.RememberMe);
            return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

    }
}

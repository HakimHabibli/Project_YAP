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

        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
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

            return RedirectToAction("Index", "Dashboard");
        }
      
    }
}

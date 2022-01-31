using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PWF.Domain.Models;
using PWF.Domain.ViewModels;
using PWF.Persistence;

namespace PWF.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AccountController(SignInManager<ApplicationUser> signInManager,UserManager<ApplicationUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model,string? returnUrl=null)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = model.EmailAddress
                };

                var identityResult = await signInManager.PasswordSignInAsync(model.EmailAddress, model.Password, model.IsRemebered, false);

                if (identityResult.Succeeded)
                {
                    if (returnUrl == null || returnUrl == "/")
                    {
                        return RedirectToAction("Index","Home");
                    }
                    else
                    {
                        return LocalRedirect(returnUrl);
                    }
                }
                ModelState.AddModelError(string.Empty, "Email Address or Password Incorrect");
            }
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Signup(SignupVM model)
        {

            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                };
                var identityResult = await userManager.CreateAsync(user, model.Password);
                if (identityResult.Succeeded)
                {
                    if (model.Email.ToLower() == "admin@gmail.com") await userManager.AddToRoleAsync(user, "Admin");
                    await userManager.AddToRoleAsync(user, "Customer");
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index","Home");
                }
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }
    }
}

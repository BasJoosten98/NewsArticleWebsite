using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewsSite.Models;
using NewsSite.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsSite.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Name,
                    Email = model.Email
                };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
        [HttpGet]
        public  IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                string userName;
                //user entered email
                if (model.EmailOrName.Contains("@"))
                {
                    var query = from u in userManager.Users
                                where u.Email == model.EmailOrName
                                select u.UserName;
                    userName = query.FirstOrDefault();
                    userName = userName != null ? userName : model.EmailOrName;
                }
                else //user entered name
                {
                    userName = model.EmailOrName;
                }
                var result = await signInManager.PasswordSignInAsync(userName, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    //return NotFound();
                    return RedirectToAction("index", "home");
                }

                ModelState.AddModelError("", "Invalid login attempt");
            }
            return View(model);
        }
    }
}

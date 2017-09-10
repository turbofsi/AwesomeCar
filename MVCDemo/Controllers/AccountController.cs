using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCDemo.DataAccess.Models;
using Microsoft.AspNetCore.Identity;

namespace MVCDemo.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<User> _signinManager;
        private UserManager<User> _userManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signinManger)
        {
            _userManager = userManager;
            _signinManager = signinManger;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = viewModel.UserName };
                var createResult  = await _userManager.CreateAsync(user, viewModel.Password);
                if (createResult.Succeeded)
                {
                    await _signinManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");   

                }
                else
                {
                    foreach (var error in createResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await _signinManager.PasswordSignInAsync(
                                            model.Username, model.Password,
                                            model.RememberMe, false);
                if (loginResult.Succeeded)
                {
                    if (Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "Could not login");
            return View(model);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signinManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
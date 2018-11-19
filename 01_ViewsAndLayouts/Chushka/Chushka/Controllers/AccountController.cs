using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chushka.Models;
using Chushka.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Chushka.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<ChushkaUser> signIn;

        public AccountController(SignInManager<ChushkaUser> signIn)
        {
            this.signIn = signIn;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            ChushkaUser user = signIn.UserManager.Users.FirstOrDefault(u => u.UserName == model.Username);

            var result =
                this.signIn.PasswordSignInAsync(user, model.Password, isPersistent: false, lockoutOnFailure: false).Result;

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var user = new ChushkaUser()
            {
                Email = model.Email,
                FullName = model.FullName,
                UserName = model.Username
            };

            var result = this.signIn.UserManager.CreateAsync(user, model.Password).Result;
            if (result.Succeeded)
            {
                await signIn.SignInAsync(user, isPersistent: false);
                if (signIn.UserManager.Users.Count() == 1)
                {
                    await signIn.UserManager.AddToRoleAsync(user, "Admin");
                }
                else
                {
                    await signIn.UserManager.AddToRoleAsync(user, "User");
                }

                return RedirectToAction("Index", "Home");
            }

            return this.View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            signIn.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}

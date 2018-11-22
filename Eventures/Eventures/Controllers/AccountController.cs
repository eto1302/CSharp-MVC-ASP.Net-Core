using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventures.Models;
using Eventures.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Eventures.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<EventuresUser> signInManager;

        public AccountController(SignInManager<EventuresUser> signInManager)
        {
            this.signInManager = signInManager;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            EventuresUser user = signInManager.UserManager.Users.FirstOrDefault(u => u.UserName == model.Username);

            var result =
                this.signInManager.PasswordSignInAsync(user, model.Password, isPersistent: false, lockoutOnFailure: false).Result;

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var user = new EventuresUser()
            {
                Email = model.Email,
                UserName = model.Username,
                UCN = model.UCN,
                FirstName = model.FirstName,
                LastName = model.LastName,
            };

            var result = this.signInManager.UserManager.CreateAsync(user, model.Password).Result;
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);
                if (signInManager.UserManager.Users.Count() == 1)
                {
                    await signInManager.UserManager.AddToRoleAsync(user, "Admin");
                }
                else
                {
                    await signInManager.UserManager.AddToRoleAsync(user, "User");
                }

                return RedirectToAction("Index", "Home");
            }

            return this.View();
        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}

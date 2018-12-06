using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Eventures.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eventures.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<EventuresUser> userManager;

        public UsersController(UserManager<EventuresUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var users = await this.userManager.Users.ProjectTo<UserListingViewModel>().ToArrayAsync();
            var admins = (await this.userManager.GetUsersInRoleAsync("Admin")).Select(r => r.Id).ToArray();
            foreach (var user in users)
            {
                user.IsAdmin = admins.Contains(user.Id);
            }

            return this.View(users.OrderByDescending(user => user.IsAdmin));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Promote(string userId)
        {
            if (userId == null || (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "Admin")))
            {
                return this.RedirectToAction("Index", "Users");
            }

            var user = await userManager.FindByIdAsync(userId);

            await this.userManager.RemoveFromRoleAsync(user, "User");

            await this.userManager.AddToRoleAsync(user, "Admin");

            return this.RedirectToAction("Index", "Users");
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Demote(string userId)
        {
            if (userId == null || (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "User")))
            {
                return this.RedirectToAction("Index", "Users");
            }

            var user = await userManager.FindByIdAsync(userId);

            await this.userManager.RemoveFromRoleAsync(user, "Admin");

            await this.userManager.AddToRoleAsync(user, "User");

            return this.RedirectToAction("Index", "Users");
        }
    }
}

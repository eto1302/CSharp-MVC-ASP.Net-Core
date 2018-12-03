using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventures.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Eventures.Middlewares
{
    public class SeedDataMiddleware
    {
        private readonly RequestDelegate next;

        public SeedDataMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetService<UserManager<EventuresUser>>();
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                var identityRole = new IdentityRole { Name = "Admin" };

                await roleManager.CreateAsync(identityRole);
            }

            if (!roleManager.RoleExistsAsync("User").Result)
            {
                var identityRole = new IdentityRole { Name = "User" };

                await roleManager.CreateAsync(identityRole);
            }

            var admin = await userManager.FindByEmailAsync("admin@adminpass");

            if (admin == null)
            {
                var user = new EventuresUser()
                {
                    UserName = "admin",
                    Email = "admin@adminpass",
                    FirstName = "FirstName",
                    LastName = "LastName",
                    UniqueCitizenNumber = "1234567890"
                };

                await userManager.CreateAsync(user, "adminpass");

                await userManager.AddToRoleAsync(user, "Admin");
            }

            await next(httpContext);
        }
    }
}

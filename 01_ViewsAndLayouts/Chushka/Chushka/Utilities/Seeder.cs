using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chushka.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Chushka.Utilities
{
    public static class Seeder
    {
        public static void Seed(IServiceProvider provider)
        {
            var roleStore = provider.GetService<RoleManager<IdentityRole>>();
            var adminRole = roleStore.Roles.FirstOrDefault(r => r.Name == "Admin");
            if (adminRole == null)
            {
                roleStore.CreateAsync(new IdentityRole("Admin"));
            }
            var userRole = roleStore.Roles.FirstOrDefault(r => r.Name == "User");
            if (userRole == null)
            {
                roleStore.CreateAsync(new IdentityRole("User"));
            }
        }
    }
}

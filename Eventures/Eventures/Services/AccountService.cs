using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventures.Data;
using Eventures.Models;
using Eventures.Services.Contracts;

namespace Eventures.Services
{
    public class AccountService : IAccountService
    {
        public ApplicationDbContext context { get; set; }

        public AccountService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public EventuresUser GetUserById(string id)
        {
            return this.context.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}

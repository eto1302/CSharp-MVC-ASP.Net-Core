using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventures.Models;

namespace Eventures.Services.Contracts
{
    interface IAccountService
    {
        EventuresUser GetUserById(string id);
    }
}

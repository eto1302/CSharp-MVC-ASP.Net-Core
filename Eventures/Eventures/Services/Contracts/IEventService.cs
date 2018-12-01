using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventures.Models;

namespace Eventures.Services.Contracts
{
    public interface IEventService
    {
        Event GetEventById(string id);
    }
}

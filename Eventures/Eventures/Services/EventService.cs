using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventures.Data;
using Eventures.Models;
using Eventures.Services.Contracts;

namespace Eventures.Services
{
    public class EventService : IEventService
    {
        public EventService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public ApplicationDbContext context { get; set; }

        public Event GetEventById(string id)
        {
            return this.context.Events.FirstOrDefault(e => e.Id == id);
        }
    }
}

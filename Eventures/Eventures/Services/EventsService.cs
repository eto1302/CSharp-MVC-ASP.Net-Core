namespace Eventures.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data;
    using Eventures.Models;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Linq;

    public class EventsService : DataService, IEventsService
    {
        public EventsService(ApplicationDbContext context) : base(context)
        {
        }

        public async Task CreateAsync(EventServiceModel model)
        {
            if (!this.IsEntityStateValid(model))
            {
                return;
            }

            var ev = Mapper.Map<Event>(model);

            await this.context.AddAsync(ev);

            await this.context.SaveChangesAsync();
        }

        public IEnumerable<EventServiceModel> GetAll()
        {
            return this.context.Events
                .Where(e => e.TotalTickets > 0)
                .ProjectTo<EventServiceModel>()
                .ToArray();
        }
    }
}
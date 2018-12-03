namespace Eventures.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface IEventsService
    {
        Task CreateAsync(EventServiceModel model);

        Task<IEnumerable<EventServiceModel>> GetAll();
    }
}
namespace Eventures.Services
{
    using Data;

    public abstract class DataService : BaseService
    {
        protected readonly ApplicationDbContext context;

        protected DataService(ApplicationDbContext context)
        {
            this.context = context;
        }
    }
}
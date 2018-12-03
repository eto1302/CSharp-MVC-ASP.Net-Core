using Eventures.Mapping;

namespace Eventures.Web.Models
{
    using System;
    using Services.Models;

    public class EventListingViewModel : IMapWith<EventServiceModel>
    {
        public string Id { get; set; }
        
        public string Name { get; set; }

        public string Place { get; set; }

        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
    }
}
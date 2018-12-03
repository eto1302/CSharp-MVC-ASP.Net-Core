using Eventures.Mapping;

namespace Eventures.Services.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Eventures.Models;

    public class OrderServiceModel : IMapWith<Order>
    {
        public string Id { get; set; }

        [Required]
        public DateTime OrderedOn { get; set; }

        public string EventId { get; set; }

        public EventServiceModel Event { get; set; }

        public string UserId { get; set; }

        public EventuresUserServiceModel User { get; set; }

        [Required]
        public int TicketsCount { get; set; }
    }
}
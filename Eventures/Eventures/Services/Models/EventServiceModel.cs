using Eventures.Mapping;

namespace Eventures.Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Eventures.Models;

    public class EventServiceModel : IMapWith<Event>
    {
        public string Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 10)]
        public string Name { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Place { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        
        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int TotalTickets { get; set; }

        [Required]
        public decimal PricePerTicket { get; set; }

        public ICollection<OrderServiceModel> Orders { get; set; }
    }
}
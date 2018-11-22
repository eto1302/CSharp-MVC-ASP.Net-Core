using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.ViewModels
{
    public class CreateEventsViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Place")]
        public string Place { get; set; }

        [Required]
        [Display(Name = "Start")]
        public DateTime Start { get; set; }

        [Required]
        [Display(Name = "End")]
        public DateTime End { get; set; }

        [Required]
        [Display(Name = "TotalTickets")]
        public int TotalTickets { get; set; }

        [Required]
        [Display(Name = "PricePerTicket")]
        public decimal PricePerTicket { get; set; }
    }
}

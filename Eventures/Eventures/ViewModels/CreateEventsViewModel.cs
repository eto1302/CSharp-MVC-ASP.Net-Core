using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Eventures.Attributes.Validation;

namespace Eventures.ViewModels
{
    public class CreateEventsViewModel
    {
        [Required]
        [Display(Name = "Name")]
        [MinLength(10)]
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
        [NonZeroInteger]
        public int TotalTickets { get; set; }

        [Required]
        [Display(Name = "PricePerTicket")]
        [RegularExpression(@"[0-9]*\.{1}[0-9]*", ErrorMessage = "Price Per Ticket should be a decimal number.")]
        public decimal PricePerTicket { get; set; }
    }
}

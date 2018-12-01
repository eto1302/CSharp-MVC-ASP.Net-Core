using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventures.Models;

namespace Eventures.ViewModels
{
    public class OrderEventViewModel
    {
        public string EventId { get; set; }

        public int TicketsCount { get; set; }

        public EventuresUser User { get; set; }
    }
}

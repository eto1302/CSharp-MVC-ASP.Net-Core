using System;
using System.Collections.Generic;
using System.Text;

namespace Eventures.Models
{
    public class Order
    {
        public string Id { get; set; }

        public DateTime OrderedOn { get; set; }

        public Event Event { get; set; }

        public EventuresUser Customer { get; set; }

        public int TicketsCount { get; set; }
    }
}

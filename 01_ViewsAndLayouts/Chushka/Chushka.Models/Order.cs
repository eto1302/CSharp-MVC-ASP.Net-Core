using System;
using System.Collections.Generic;
using System.Text;

namespace Chushka.Models
{
    public class Order
    {
        //    •	Has an Id – a GUID string or integer.
        //•	Has a Product – a Product
        //•	Has a Client – an User
        //•	Has an Ordered On – a DateTime
        public int Id { get; set; }
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
        public ChushkaUser Client { get; set; }
        public DateTime OrderedOn { get; set; }

    }
}

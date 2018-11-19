using System;
using System.Collections.Generic;
using System.Text;
using Chushka.Models.Enums;

namespace Chushka.Models
{
    public class Product
    {
    //    •	Has an Id – a GUID string or integer.
    //•	Has a Name
    //•	Has a Price –  think of the right data type here
    //•	Has a Description
    //•	Has a Type – can be one of the following values(“Food”, “Domestic”, “Health”, “Cosmetic”, “Other”)
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public ProductType Type { get; set; }
    }
}

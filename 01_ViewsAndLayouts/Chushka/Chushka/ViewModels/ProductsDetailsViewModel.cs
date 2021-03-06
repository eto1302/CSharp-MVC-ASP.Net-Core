﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chushka.ViewModels
{
    public class ProductsDetailsViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
        
        public string Type { get; set; }

        public int Id { get; set; }
    }
}

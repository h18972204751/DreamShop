﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Model
{
    public class ProductType:BaseModel
    {

        public string Name { get; set; }

        public string Code { get; set; }

        public ICollection<Products> Product { get; set; }
    }
}

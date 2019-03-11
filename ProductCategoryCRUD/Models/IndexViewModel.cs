﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductCategoryCRUD.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
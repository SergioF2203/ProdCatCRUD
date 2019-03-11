using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductCategoryCRUD.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
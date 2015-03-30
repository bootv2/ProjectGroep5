using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebWinkelGroep5.Models
{
    public class ProductModel
    {
        public String name{get; set;}
        public String details { get; set; }
        public String imageURL { get; set; }
        public int price { get; set; }
        public int productId { get; set; }

    }
}
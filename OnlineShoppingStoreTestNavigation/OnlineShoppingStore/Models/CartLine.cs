using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.Models
{
    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        //public string SelectSize { get; set; }
        //public string SelectColour { get; set; }
    }
}
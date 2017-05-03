using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.Entities
{
    //MIGHT NOT NEED THIS!!!
    public class ProductEntities
    {

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicsStores.Models
{
    public class ShopingCart
    {

        public Product product { get; set; }
        public int quantity  { get; set; }


        public ShopingCart (Product product,int quantity)
        {
            this.product = product;
            this.quantity = quantity;
        }

    }



}
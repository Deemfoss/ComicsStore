using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicsStores.Models
{
    public class Product
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public string Price { get; set; }
       public string Discription { get; set; }
       public string Brand { get;  set; }
       public DateTime Date { get; set; }
       public string Url { get; set; }
        public int Category { get; set; }
    //   public Category Category { get; set; }
  //public  Purchas Purchas { get; set; }

    }


public class Category
    {
       public int Id { get; set; }
       public string Name { get; set; }
        
       //public  Product Product { get; set; }
    }



}
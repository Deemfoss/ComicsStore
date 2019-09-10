using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ComicsStores.Models;

namespace ComicsStores.Models
{
    public class Purchase
    {
    ShopingCart ShopingCart { get; set; }
    public    int Id { get; set; }
    public    DateTime Data { get; set; }
    public    string NameUser { get; set; }
    public    string Mail { get; set; }
    public   string Delivey { get; set; }
    public   string Adress { get; set; }
   public  string PhoneNumber { get; set; }
    }
    
}
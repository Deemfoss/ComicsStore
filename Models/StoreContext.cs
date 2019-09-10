using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ComicsStores.Models
{
    public class StoreContext : DbContext
    {
        // public StoreContext():base("ComicsStoreDB") { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categoryies { get; set; }
        public DbSet<Purchas> Purchases { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
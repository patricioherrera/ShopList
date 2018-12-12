using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class ShopListContext : DbContext
    {
        public ShopListContext()    : base("myConnectionStringDBShopList")
        {

        }
        public DbSet<Father> Fathers { get; set; }
        public DbSet<Son> Sons { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShopList> ShopLists { get; set; }
    }
}
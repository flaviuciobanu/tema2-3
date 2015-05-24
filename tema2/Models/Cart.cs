using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace tema2.Models
{
    
    public class CartDBContext : DbContext
    {
        public DbSet<Bere> cart { get; set; }
    }
}
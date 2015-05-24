using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace tema2.Models
{
    public class Bere
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public DateTime DataFabricatie { get; set; }
        public double ProcentAlcool { get; set; }
        public decimal Pret { get; set; }
    }
    public class BereDBContext : DbContext
    {
        public DbSet<Bere> Beri { get; set; }
    }
}
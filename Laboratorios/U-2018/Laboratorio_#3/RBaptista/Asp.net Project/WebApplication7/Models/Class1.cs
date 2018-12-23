using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication7.Models
{
    public class Productor
    {
        public int Id { get; set; }
        public String Titulo { get; set; }
        public String Director { get; set; }
        public DateTime Fecha { get; set; }
    }
    public class ProductorContext : DbContext
    {
        public DbSet<Productor> Productores { get; set; }
    }
}
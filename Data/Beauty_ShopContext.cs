using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Beauty_Shop.Models;

namespace Beauty_Shop.Data
{
    public class Beauty_ShopContext : DbContext
    {
        public Beauty_ShopContext (DbContextOptions<Beauty_ShopContext> options)
            : base(options)
        {
        }

        public DbSet<Beauty_Shop.Models.Produs> Produs { get; set; }

        public DbSet<Beauty_Shop.Models.Status> Status { get; set; }

        public DbSet<Beauty_Shop.Models.Categorie> Categorie { get; set; }
    }
}

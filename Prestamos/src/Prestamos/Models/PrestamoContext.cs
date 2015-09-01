using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prestamos.Models
{
    public class PrestamoContext : DbContext
    {
        public PrestamoContext(DbContextOptions options)
            :base(options)
        {
        }

        public DbSet<Prueba> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /*
            modelBuilder.Entity<Cliente>()
                .Property(c => c.Cedula)
                .Required();
            
            */
        }
    }
}

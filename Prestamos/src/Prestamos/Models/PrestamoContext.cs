using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Negocios;
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

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Cliente>()
                .Property(c => c.Cedula)
                .Required();

            modelBuilder.Entity<Cliente>()
                .Property(c => c.PrimerNombre)
                .Required();

            modelBuilder.Entity<Cliente>()
                .Property(c => c.SegundoNombre)
                .Required();

            modelBuilder.Entity<Cliente>()
                .Property(c => c.PrimerApellido)
                .Required();

            modelBuilder.Entity<Cliente>()
                .Property(c => c.SegundoApellido)
                .Required();
        }
    }
}

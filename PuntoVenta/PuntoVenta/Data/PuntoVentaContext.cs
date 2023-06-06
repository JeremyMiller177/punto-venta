using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PuntoVenta.Models;

namespace PuntoVenta.Data
{
    public class PuntoVentaContext : DbContext
    {
        public PuntoVentaContext (DbContextOptions<PuntoVentaContext> options)
            : base(options)
        {
        }

        public DbSet<PuntoVenta.Models.Usuario> Usuario { get; set; } = default!;

        public DbSet<PuntoVenta.Models.TipoProducto> TipoProducto { get; set; } = default!;

        public DbSet<PuntoVenta.Models.Producto> Producto { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoProducto>()
                .HasMany(e => e.Productos)
                .WithOne(e => e.TipoProducto)
                .HasForeignKey(e => e.TipoProductoId)
                .HasPrincipalKey(e => e.Id);
        }
    }
}

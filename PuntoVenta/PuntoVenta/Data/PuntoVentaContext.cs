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

        public DbSet<PuntoVenta.Models.VentaEncabezado> VentaEncabezado { get; set; } = default!;

        public DbSet<PuntoVenta.Models.VentaDetalle> VentaDetalle { get; set; } = default!;

        public DbSet<PuntoVenta.Models.Cliente> Cliente { get; set; } = default!;
    }
}

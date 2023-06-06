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
    }
}

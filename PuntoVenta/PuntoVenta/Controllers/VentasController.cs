using Microsoft.AspNetCore.Mvc;
using PuntoVenta.Models;
using PuntoVenta.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace PuntoVenta.Controllers
{
    public class VentasController : Controller
    {
        private readonly PuntoVentaContext _context;

        public VentasController(PuntoVentaContext context)
        {
            _context = context;
        }

        // GET: Ventas
        public async Task<IActionResult> Index()
        {
            var puntoVentaContext = _context.VentaEncabezado.Include(p => p.Usuario).Include(p => p.Cliente).Include(p => p.VentaDetalles);
            return View(await puntoVentaContext.ToListAsync());
        }

        // GET: VentaDetalle
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VentaEncabezado == null)
            {
                return NotFound();
            }

            var venta = await _context.VentaEncabezado
                .Include(p => p.Usuario)
                .Include(p => p.Cliente)
                .Include(p => p.VentaDetalles)
                .ThenInclude(d => d.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        public IActionResult Create()
        {
            VentaEncabezado ventaEncabezado = new VentaEncabezado();
            ventaEncabezado.VentaDetalles?.Add(new VentaDetalle() { Id = 1 });

            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Nombre");
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Nombre");
            ViewData["ProductoId"] = new SelectList(_context.Producto, "Id", "Nombre");

            return View(ventaEncabezado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VentaEncabezado venta)
        {
            if (ModelState.IsValid)
            {
                foreach (var detalle in venta.VentaDetalles)
                {
                    detalle.Subtotal = detalle.Cantidad * detalle.PrecioUnitario;
                    venta.Total += detalle.Subtotal;
                }

                _context.Add(venta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Nombre");
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Nombre");
            ViewData["ProductoId"] = new SelectList(_context.Producto, "Id", "Nombre");
            return View(venta);
        }
    }

}

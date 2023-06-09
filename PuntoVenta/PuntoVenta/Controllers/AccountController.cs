using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using PuntoVenta.Data;
using PuntoVenta.Models;
using System.Threading.Tasks;
using System.Security.Claims;

namespace PuntoVenta.Controllers
{
    public class AccountController : Controller
    {
        private readonly PuntoVentaContext _context;

        public AccountController(PuntoVentaContext context)
        {
            _context = context;
        }

        // Acción para mostrar la vista de registro
        public IActionResult Register()
        {
            return View();
        }

        // Acción para procesar el registro del usuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Id,Nombre,Correo,Contrasena")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login", "Account");
            }

            return RedirectToAction("Login", "Account");
        }

        // Acción para mostrar la vista de inicio de sesión
        public IActionResult Login()
        {
            return View();
        }

        // Acción para procesar el inicio de sesión del usuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Correo,Contrasena")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Usuario.FirstOrDefaultAsync(u => u.Correo == usuario.Correo && u.Contrasena == usuario.Contrasena);

                if (user != null)
                {
                    // Crear el objeto ClaimsIdentity para el usuario autenticado
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Correo)
                        // Puedes agregar más claims según tus necesidades
                    };

                    var identity = new ClaimsIdentity(claims, "PuntoVentaAuth");

                    // Crear el objeto ClaimsPrincipal y establecer la autenticación
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(principal);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Credenciales inválidas");
                }
            }

            return RedirectToAction("Index", "Home");
        }

        // Acción para cerrar sesión
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // Cerrar la sesión del usuario y eliminar la cookie de autenticación
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "Account");
        }
    }
}

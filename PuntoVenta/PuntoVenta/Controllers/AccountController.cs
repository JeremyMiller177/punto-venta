using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PuntoVenta.Data;
using PuntoVenta.Models;

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
        public IActionResult Register(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                // Aquí debes agregar el código para guardar el usuario en la base de datos
                // Ejemplo: _dbContext.Usuarios.Add(usuario);
                // Guardar cambios en la base de datos: _dbContext.SaveChanges();

                return RedirectToAction("Login");
            }

            return View(usuario);
        }

        // Acción para mostrar la vista de inicio de sesión
        public IActionResult Login()
        {
            return View();
        }

        // Acción para procesar el inicio de sesión del usuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Usuario.FirstOrDefault(u => u.Correo == usuario.Correo && u.Contrasena == usuario.Contrasena);

                if (user != null)
                {
                    // El inicio de sesión es exitoso, puedes guardar la información del usuario en la sesión si lo deseas
                    // Ejemplo: HttpContext.Session.SetString("UserId", user.Id.ToString());

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Credenciales inválidas");
                }
            }

            return View(usuario);
        }

    }
}

using Microsoft.AspNetCore.Mvc;

namespace PuntoVenta.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: /Usuario/
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Usuario/Welcome
        public string Welcome()
        {
            return "Esta es la pagina de bienvenida...";
        }
    }
}

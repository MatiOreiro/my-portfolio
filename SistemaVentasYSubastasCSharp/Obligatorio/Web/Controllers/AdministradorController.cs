using Obligatorio;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class AdministradorController : Controller
    {
        public IActionResult IndexAdmin()
        {

            return View();
        }

        public IActionResult VerSubastas()
        {
            List<Subasta> subastas = Sistema.Instancia.ObtenerSubastasOrdenadasPorFecha();
            return View(subastas);
        }

    }
}

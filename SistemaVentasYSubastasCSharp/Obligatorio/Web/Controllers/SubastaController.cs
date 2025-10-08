using Obligatorio;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class SubastaController : Controller
    {
        [HttpGet]
        public IActionResult Ofertar(int id)
        {
            Subasta subasta = Sistema.Instancia.BuscarSubasta(id);
            return View(subasta);
        }

        [HttpPost]
        public IActionResult Ofertar(int id, double monto)
        {
            try
            {
                Subasta subasta = Sistema.Instancia.BuscarSubasta(id);
                Cliente ofertante = Sistema.Instancia.BuscarClientePorEmail(SessionExtensions.GetString(HttpContext.Session, "usuario"));
                subasta.AltaOferta(ofertante, monto, DateTime.Now);
                ViewBag.Mensaje = "Oferta registrada correctamente";
                return RedirectToAction("VerPublicacionesCliente", "Cliente");
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            return View("VerPublicacionesCliente", "Cliente");
        }

        public IActionResult CerrarSubasta(int id)
        {
            try
            {
                Subasta subasta = Sistema.Instancia.BuscarSubasta(id);
                if(subasta.ofertas.Count() > 0)
                {
                Cliente cliente = subasta.OfertaMasAlta().usuario;
                Sistema.Instancia.CerrarSubasta(id, cliente);
                    ViewBag.Mensaje = "Subasta cerrada con éxito";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            return RedirectToAction("VerSubastas", "Administrador");
        }

    }
}


using Microsoft.AspNetCore.Mvc;
using Obligatorio;

namespace Web.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult IndexCliente()
        {
            Cliente cliente = Sistema.Instancia.BuscarClientePorEmail(SessionExtensions.GetString(HttpContext.Session, "usuario"));
            ViewBag.Mensaje = "Bienvenido " + cliente.nombre + " " + cliente.apellido;
            ViewBag.Saldo = "Saldo: $" + cliente.saldo;
            return View();
        }

        // NO VALIDA EMAIL
        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registro(Cliente cliente)
        {
            try
            {
                cliente.Validar();
                Sistema.Instancia.InscribirCliente(cliente);
                ViewBag.Mensaje = "Cliente registrado correctamente";
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            return View();
        }
        //NO VALIDA EMAIL

        public IActionResult VerPublicacionesCliente()
        {
            List<Publicacion> publicaciones = Sistema.Instancia.ObtenerPublicaciones();

            return View(publicaciones);
        }

        public IActionResult Comprar(int id)
        {
            try
            {
                Cliente comprador = Sistema.Instancia.BuscarClientePorEmail(SessionExtensions.GetString(HttpContext.Session, "usuario"));
                Sistema.Instancia.ComprarVenta(id, comprador);
                ViewBag.Mensaje = "Compra registrada correctamente";
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            return RedirectToAction(nameof(VerPublicacionesCliente));
        }

        [HttpGet]
        public IActionResult CargarSaldo()
        {
            return View();
        }

        public IActionResult CargarSaldo(double monto)
        {
            try
            {
                Cliente cliente = Sistema.Instancia.BuscarClientePorEmail(SessionExtensions.GetString(HttpContext.Session, "usuario"));
                if(cliente != null && monto > 0)
                {
                    cliente.CargarSaldo(monto);
                    ViewBag.Mensaje = "Saldo cargado correctamente";
                    ViewBag.Mensaje = "Nuevo saldo: $" + cliente.saldo;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            return View();
        }
    }
    

}

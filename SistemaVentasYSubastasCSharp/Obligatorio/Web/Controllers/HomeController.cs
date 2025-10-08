using Microsoft.AspNetCore.Mvc;
using Obligatorio;
using System.Diagnostics;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            try
            {
                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {
                    Usuario usuario = Sistema.Instancia.BuscarUsuarioParaLogin(email, password);
                    if (usuario != null)
                    {
                        string rol = usuario.ObtenerRol();
                        HttpContext.Session.SetString("usuario", usuario.email);
                        HttpContext.Session.SetString("rol", rol);
                        if (rol.Trim().ToUpper().Equals("CLIENTE"))
                        {
                            return RedirectToAction("IndexCliente", "Cliente");
                        }
                        else
                        {
                            return RedirectToAction("IndexAdmin", "Administrador");
                        }

                    }
                    else
                    {
                        ViewBag.Mensaje = "Usuario o contraseña incorrectos";
                    }
                }
                else
                {
                    ViewBag.Mensaje = "El usuario y la contraseña son obligatorios";
                }
            }
            catch (Exception ex)
            {
                return ViewBag.Mensaje = ex.Message;
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        
    }
}

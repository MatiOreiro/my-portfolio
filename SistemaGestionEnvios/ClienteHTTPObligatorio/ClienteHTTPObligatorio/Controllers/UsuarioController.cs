using ClienteHTTPObligatorio.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace ClienteHTTPObligatorio.Controllers
{
    public class UsuarioController : Controller
    {
        private HttpClient _httpClient;

        public UsuarioController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://webapiobligatoriop3oreirohohl-d6c6e0g6g0fedbgd.brazilsouth-01.azurewebsites.net/");
        }
        [HttpGet]
        public IActionResult CambiarContrasenia()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CambiarContrasenia(string anteriorContrasenia, string nuevaContrasenia)
        {
            string token = HttpContext.Session.GetString("Token");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            CambiarContraseniaDTO dto = new CambiarContraseniaDTO(anteriorContrasenia, nuevaContrasenia);
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync("/api/usuario/cambiarContrasenia", dto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Error al cambiar la contraseña.");
                return View();
            }
        }
    }
}

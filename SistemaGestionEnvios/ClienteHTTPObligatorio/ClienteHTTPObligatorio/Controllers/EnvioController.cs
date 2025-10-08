using ClienteHTTPObligatorio.Models;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ClienteHTTPObligatorio.Controllers
{
    public class EnvioController : Controller
    {
        private HttpClient _httpClient;

        public EnvioController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://webapiobligatoriop3oreirohohl-d6c6e0g6g0fedbgd.brazilsouth-01.azurewebsites.net/");
        }

        public async Task<IActionResult> Index()
        {
            string token = HttpContext.Session.GetString("Token");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await _httpClient.GetAsync("/api/envio");

            if (response.IsSuccessStatusCode)
            {

                string content = await response.Content.ReadAsStringAsync();

                var envios = JsonSerializer.Deserialize<List<EnvioDTO>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return View(envios);
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            string token = HttpContext.Session.GetString("Token");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"/api/envio/byId/{id}");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var envio = JsonSerializer.Deserialize<EnvioDTO>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return View(envio);
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult BuscarPorTracking()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BuscarPorTracking(int nroTracking)
        {
            string token = HttpContext.Session.GetString("Token");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"/api/envio/byTracking/{nroTracking}");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var envio = JsonSerializer.Deserialize<EnvioDTO>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return View("Details", envio);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                ModelState.AddModelError("", "No se encontró el envío con el número de tracking proporcionado.");
                return View("Index");
            }
            else
            {
                ModelState.AddModelError("", "Ocurrió un error al procesar la solicitud.");
                return View("Index");
            }
        }

        [HttpGet]
        public IActionResult EnviosPorFechas()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EnviosPorFechas(DateTime f1, DateTime f2)
        {
            if (f1 > f2)
            {
                ModelState.AddModelError("", "La fecha de inicio no puede ser posterior a la fecha de fin.");
                return View();
            }
            string token = HttpContext.Session.GetString("Token");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            string f1Str = f1.ToString("yyyy-MM-dd");
            string f2Str = f2.ToString("yyyy-MM-dd");
            HttpResponseMessage response = await _httpClient.GetAsync($"/api/envio/filtroFechas?f1={f1Str}&f2={f2Str}");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var envios = JsonSerializer.Deserialize<List<EnvioDTO>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return View(envios);
            }
            else
            {
                ModelState.AddModelError("", "Ocurrió un error al procesar la solicitud.");
                return View();
            }
        }

        [HttpGet]
        public IActionResult EnviosPorComentario()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EnviosPorComentario(string palabra)
        {
            if (string.IsNullOrWhiteSpace(palabra))
            {
                ModelState.AddModelError("", "El comentario no puede estar vacío.");
                return View();
            }
            string token = HttpContext.Session.GetString("Token");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"/api/envio/filtroPalabra?palabra={palabra}");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var envios = JsonSerializer.Deserialize<List<EnvioDTO>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return View(envios);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                ModelState.AddModelError("", "No se encontró el envío con el comentario proporcionado.");
                return View("Index");
            }
            else
            {
                ModelState.AddModelError("", "Ocurrió un error al procesar la solicitud.");
                return View("Index");
            }
        }
    }
}

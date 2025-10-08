using ClienteHTTPObligatorio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using System.Text;
using System.Text.Json;

namespace ClienteHTTPObligatorio.Controllers
{
    public class AuthController : Controller
    {
        private HttpClient _httpClient;

        public AuthController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://webapiobligatoriop3oreirohohl-d6c6e0g6g0fedbgd.brazilsouth-01.azurewebsites.net/");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginDTO dto)
        {
            var json = JsonSerializer.Serialize(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/auth/login", content);

            if(response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(result, new JsonSerializerOptions 
                { 
                    PropertyNameCaseInsensitive = true 
                });
                // Store the token in session
                HttpContext.Session.SetString("Token", tokenResponse.Token);
                return RedirectToAction("Index", "Home");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                ModelState.AddModelError("", "Datos incorrectos.");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                ModelState.AddModelError("", "Usuario no encontrado.");
            }
            else
            {
                ModelState.AddModelError("", "An error occurred while processing your request.");
            }

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}

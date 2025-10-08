using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.DTOs.DTOs.DTOUsuario;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using System.Security.Claims;

namespace Obligatorio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private ICUCambiarContrasenia cUCambiarContrasenia;
        public UsuarioController(ICUCambiarContrasenia cUCambiarContrasenia)
        {
            this.cUCambiarContrasenia = cUCambiarContrasenia;
        }
        [HttpPut("cambiarContrasenia")]
        [Authorize(Roles = "Cliente")]
        public IActionResult CambiarContrasenia([FromBody] CambiarContraseniaDTO dto)
        {
            try
            {
                string email = EmailUser();
                cUCambiarContrasenia.Ejecutar(email, dto);
                return Ok("Contraseña cambiada correctamente.");
            }
            catch (UsuarioNoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (PasswordNoValidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (PasswordIgualesException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error inesperado: " + ex.Message);
            }
        }

        private string EmailUser()
        {
            string email = null;
            var claimsIdentity = User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                var emailClaim = claimsIdentity.Claims
                .FirstOrDefault(claim => claim.Type == ClaimTypes.Email);
                email = emailClaim.Value;
            }
            return email;
        }
    }
}

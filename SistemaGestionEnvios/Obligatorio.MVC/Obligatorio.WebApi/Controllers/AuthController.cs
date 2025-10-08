using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Obligatorio.DTOs.DTOs.DTOAuth;
using Obligatorio.DTOs.DTOs.DTOUsuario;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Obligatorio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ICULogin _CULogin;

        public AuthController(ICULogin cULogin)
        {
            _CULogin = cULogin;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO dto)
        {
            try
            {
                UsuarioDTO u = _CULogin.VerificarDatosParaLogin(new UsuarioDTO() { Email = dto.Email, Password = dto.Password });
                var clave = "UTzl^7yPl$5xrT6&{7RZCSG&O42MEK89$CW1XXRrN(>XqIp{W4s2S5$>KT$6CG!2M]'ZlrqH-t%eI4.X9W~u#qO+oX£+[?7QDAa";
                var claveCodificada = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(clave));
                List<Claim> claims = [
                new Claim(ClaimTypes.Email, u.Email),
                new Claim(ClaimTypes.Role, u.Rol)
                ];
                var credenciales = new SigningCredentials(claveCodificada, SecurityAlgorithms.HmacSha512Signature);
                var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: credenciales);
                var jwt = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(new { Token = jwt });
            }
            catch (BadLoginException e)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                if (e is UnauthorizedAccessException)
                {
                    return Unauthorized();
                }
                else
                {
                    return BadRequest(e.Message);
                }
            }
        }
    }
}

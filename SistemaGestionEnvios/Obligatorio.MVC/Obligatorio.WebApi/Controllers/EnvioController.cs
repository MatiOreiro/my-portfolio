using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.DTOs.DTOs.DTOEnvio;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUEnvio;
using System.Security.Claims;

namespace Obligatorio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvioController : ControllerBase
    {
        private ICUObtenerEnvioPorTracking _CUObtenerEnvioPorTracking;
        private ICUObtenerComentarios _CUObtenerComentarios;
        private ICUObtenerEnviosPorMail _CUObtenerEnviosPorMail;
        private ICUObtenerEnviosDeClienteEntreFechas _CUObtenerEnviosDeClienteEntreFechas;
        private ICUObtenerEnviosPorMailYEstado _CUObtenerEnviosPorMailYEstado;
        private ICUObtenerEnvio _CUObtenerEnvio;
        public EnvioController(ICUObtenerEnvioPorTracking cUObtenerEnvioPorTracking, ICUObtenerComentarios cUObtenerComentarios, ICUObtenerEnviosPorMail CUObtenerEnviosPorMail, ICUObtenerEnviosDeClienteEntreFechas cUObtenerEnviosDeClienteEntreFechas, ICUObtenerEnviosPorMailYEstado CUObtenerEnviosPorMailYEstado, ICUObtenerEnvio cUObtenerEnvio)
        {
            _CUObtenerEnvioPorTracking = cUObtenerEnvioPorTracking;
            _CUObtenerComentarios = cUObtenerComentarios;
            _CUObtenerEnviosPorMail = CUObtenerEnviosPorMail;
            _CUObtenerEnviosDeClienteEntreFechas = cUObtenerEnviosDeClienteEntreFechas;
            _CUObtenerEnviosPorMailYEstado = CUObtenerEnviosPorMailYEstado;
            _CUObtenerEnvio = cUObtenerEnvio;
        }

        [HttpGet("byTracking/{nroTracking}")]
        public IActionResult GetEnvioPorTracking(int nroTracking)
        {
            try
            {
                EnvioDTO envio = _CUObtenerEnvioPorTracking.ObtenerEnvioPorTracking(nroTracking);
                envio.Seguimiento = _CUObtenerComentarios.ObtenerComentarios(envio.Id);
                if (envio == null)
                {
                    return NotFound();
                }
                return Ok(envio);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error inesperado");
            }

        }

        [HttpGet]
        [Authorize(Roles = "Cliente")]
        public IActionResult GetEnviosPorEmail()
        {
            string email = EmailUser();
            try
            {
                List<EnvioDTO> envios = _CUObtenerEnviosPorMail.Ejecutar(email);
                return Ok(envios);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error inesperado");
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

        [HttpGet("filtroFechas")]
        [Authorize(Roles = "Cliente")]
        public IActionResult GetEnviosPorEmailYFechas(DateTime f1, DateTime f2)
        {
            Thread.Sleep(1000);
            string email = EmailUser();
            try
            {
                List<EnvioDTO> envios = _CUObtenerEnviosDeClienteEntreFechas.Ejecutar(email, f1, f2);
                return Ok(envios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error inesperado");
            }
        }

        [HttpGet("filtroPalabra")]
        [Authorize(Roles = "Cliente")]
        public IActionResult GetEnviosPorEmailYPalabra(string palabra)
        {
            Thread.Sleep(1000);
            string email = EmailUser();
            try
            {
                List<EnvioDTO> envios = _CUObtenerEnviosPorMailYEstado.Ejecutar(email, palabra);
                return Ok(envios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error inesperado");
            }
        }

        [HttpGet("byId/{id}")]
        [Authorize(Roles = "Cliente")]
        public IActionResult GetEnviosPorId(int id)
        {
            try
            {
                EnvioDTO envio = _CUObtenerEnvio.ObtenerEnvio(id);
                if (envio == null)
                {
                    return NotFound();
                }
                return Ok(envio);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error inesperado");
            }
        }
    }
}

using Obligatorio.DTOs.DTOs.DTOEnvio;
using Obligatorio.DTOs.DTOs.DTOSeguimiento;

namespace Obligatorio.MVC.Models
{
    public class MostrarComentariosViewModel
    {
        public EnvioDTO EnvioDTO { get; set; }
        public List<SeguimientoDTO> Comentarios { get; set; }
    }
}

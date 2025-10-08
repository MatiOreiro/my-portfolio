using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.DTOs.DTOEnvio
{
    public class AgregarSeguimientoDTO
    {
        public int IdEnvio { get; set; }
        public string Comentario { get; set; }
        public int LogueadoId { get; set; }
        public AgregarSeguimientoDTO(int idEnvio, string comentario, int idUsuario)
        {
            IdEnvio = idEnvio;
            Comentario = comentario;
            LogueadoId = idUsuario;
        }
        public AgregarSeguimientoDTO()
        {
        }
    }
}

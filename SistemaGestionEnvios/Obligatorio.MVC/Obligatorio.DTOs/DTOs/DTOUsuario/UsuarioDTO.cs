using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.DTOs.DTOUsuario
{
    public class UsuarioDTO
    {
        [JsonIgnore]
        public int? Id { get; set; }
        [JsonIgnore]
        public string Nombre { get; set; }
        [JsonIgnore]
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public string Rol { get; set; }
        [JsonIgnore]
        public int? LogueadoId { get; set; }
    }
}

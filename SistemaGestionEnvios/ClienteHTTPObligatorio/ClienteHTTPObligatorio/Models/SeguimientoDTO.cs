using System.ComponentModel;

namespace ClienteHTTPObligatorio.Models
{
    public class SeguimientoDTO
    {
        public int Id { get; set; }
        public string NombreFuncionario { get; set; }
        public string Comentario { get; set; }
        public DateTime Fecha { get; set; }
    }
}

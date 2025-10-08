using System.ComponentModel;

namespace ClienteHTTPObligatorio.Models
{
    public class EnvioDTO
    {
        public string TipoEnvio { get; set; }
        public int Id { get; set; }
        public int NroTracking { get; set; }
        public int IdFuncionario { get; set; }
        public string NombreFuncionario { get; set; }
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string EmailCliente { get; set; }
        public decimal Peso { get; set; }
        public string Estado { get; set; }
        public string Direccion { get; set; }
        public string Valor { get; set; }
        public List<SeguimientoDTO> Seguimiento { get; set; } = new List<SeguimientoDTO>();
    }
}

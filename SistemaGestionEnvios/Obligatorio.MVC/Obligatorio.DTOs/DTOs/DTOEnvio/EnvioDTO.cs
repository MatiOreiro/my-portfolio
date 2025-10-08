using Obligatorio.DTOs.DTOs.DTOAgencia;
using Obligatorio.DTOs.DTOs.DTOSeguimiento;
using Obligatorio.DTOs.DTOs.DTOUsuario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.DTOs.DTOEnvio
{
    public class EnvioDTO
    {
        [DisplayName("Tipo de envío")]
        public string TipoEnvio { get; set; } 
        public int Id { get; set; }
        [DisplayName("Número de tracking")]
        public int NroTracking { get; set; }
        public int IdFuncionario { get; set; }
        [DisplayName("Nombre del funcionario")]
        public string NombreFuncionario { get; set; }
        public int IdCliente { get; set; }
        [DisplayName("Nombre del cliente")]
        public string NombreCliente { get; set; }
        [DisplayName("Email del cliente")]
        public string EmailCliente { get; set; }
        public decimal Peso { get; set; }
        public string Estado { get; set; }
        public string Direccion { get; set; }
        public string Valor { get; set; }
        public List<SeguimientoDTO> Seguimiento { get; set; } = new List<SeguimientoDTO>();

        public EnvioDTO(string tipoEnvio, int id, int nroTracking, int idFuncionario, string nombreFuncionario, int idCliente, string nombreCliente, string emailCliente, decimal peso, string estado, string direccion, string valor)
        {
            TipoEnvio = tipoEnvio;
            Id = id;
            NroTracking = nroTracking;
            IdFuncionario = idFuncionario;
            NombreFuncionario = nombreFuncionario;
            IdCliente = idCliente;
            NombreCliente = nombreCliente;
            EmailCliente = emailCliente;
            Peso = peso;
            Estado = estado;
            Direccion = direccion;
            Valor = valor;
        }

        public EnvioDTO()
        {
        }
    }
}

using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.DTOs.DTOEnvio
{
    public class AltaEnvioDTO
    {
        public int Id { get; set; }
        public int IdFuncionario { get; set; }
        [DisplayName("E-mail del cliente")]
        public string MailCliente { get; set; }
        public decimal Peso { get; set; }
        public int IdAgencia {  get; set; }
        public string Direccion { get; set; }
        public string TipoEnvio { get; set; }

        public AltaEnvioDTO(int id, int idFuncionario, string mailCliente, decimal peso, int idAgencia, string tipoEnvio)
        {
            Id = id;
            IdFuncionario = idFuncionario;
            MailCliente = mailCliente;
            Peso = peso;
            IdAgencia = idAgencia;
            TipoEnvio = tipoEnvio;
        }

        public AltaEnvioDTO()
        {
        }
    }
}
using Obligatorio.LogicaNegocio.Enumerados.EnvioEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public abstract class Envio
    {
        public int Id { get; set; }
        public int NroTracking { get; set; }
        public Usuario Funcionario { get; set; }
        public Usuario Cliente { get; set; }
        public decimal Peso { get; set; }
        public EstadoEnvio Estado { get; set; }
        public List<Seguimiento> Seguimiento { get; set; } = new List<Seguimiento>();

        public Envio()
        {
        }

        public Envio(int nroTracking, Usuario funcionario, Usuario cliente, decimal peso, EstadoEnvio estado)
        {
            NroTracking = nroTracking;
            Funcionario = funcionario;
            Cliente = cliente;
            Peso = peso;
            Estado = estado;
        }


        public abstract void FinalizarEnvio();
    }
}

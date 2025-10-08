using Obligatorio.LogicaNegocio.Enumerados.EnvioEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Comun : Envio
    {
        public Agencia Agencia { get; set; }

        public Comun() { }
        public Comun(int nroTracking, Usuario funcionario, Usuario cliente, decimal peso, EstadoEnvio estado, Agencia agencia) : base(nroTracking, funcionario, cliente, peso, estado)
        {
            Agencia = agencia;
        }

        public override void FinalizarEnvio() 
        {
            this.Estado = EstadoEnvio.FINALIZADO;
        }
    }
}

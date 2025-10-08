using Obligatorio.LogicaAplicacion.ICasosUso.ICUEnvio;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUEnvio
{
    public class CUFinalizarEnvio : ICUFinalizarEnvio
    {
        private IRepositorioEnvio _repoEnvio;
        private IRepositorioAuditoria _repoAuditoria;
        public CUFinalizarEnvio(IRepositorioEnvio repoEnvio, IRepositorioAuditoria repoAuditoria)
        {
            _repoEnvio = repoEnvio;
            _repoAuditoria = repoAuditoria;
        }
        public void FinalizarEnvio(int idEnvio)
        {
            Envio envio = _repoEnvio.FindById(idEnvio);
            envio.FinalizarEnvio();
            _repoEnvio.Update(envio);

            _repoAuditoria.Auditar(new Auditoria(envio.Funcionario.Id, "UPDATE", envio.GetType().Name, idEnvio.ToString(), "Envio finalizado correctamente "));
        }
    }
}

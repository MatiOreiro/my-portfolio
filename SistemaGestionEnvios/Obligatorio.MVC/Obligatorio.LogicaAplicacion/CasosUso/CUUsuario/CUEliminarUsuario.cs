using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUEliminarUsuario : ICUEliminarUsuario
    {
        private IRepositorioUsuario _repoUsuario;
        private IRepositorioAuditoria _repoAuditoria;

        public CUEliminarUsuario(IRepositorioUsuario repoUsuario, IRepositorioAuditoria repoAuditoria)
        {
            _repoUsuario = repoUsuario;
            _repoAuditoria = repoAuditoria;
        }

        public void EliminarUsuario(int id, int? logueadoId)
        {
            Usuario usuario = _repoUsuario.FindById(id);
            _repoUsuario.Remove(id);
            _repoAuditoria.Auditar(new Auditoria(logueadoId, "DELETE", usuario.GetType().Name, id.ToString(), "Usuario eliminado correctamente" + JsonSerializer.Serialize(usuario)));
        }
    }
}

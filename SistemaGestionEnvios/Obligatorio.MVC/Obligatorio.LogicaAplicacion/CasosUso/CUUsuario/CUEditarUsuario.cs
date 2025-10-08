using Obligatorio.DTOs.DTOs.DTOUsuario;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using Obligatorio.LogicaNegocio.VO.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUEditarUsuario : ICUEditarUsuario
    {
        private IRepositorioUsuario _repoUsuario;
        private IRepositorioAuditoria _repoAuditoria;

        public CUEditarUsuario(IRepositorioUsuario repoUsuario, IRepositorioAuditoria repoAuditoria)
        {
            _repoUsuario = repoUsuario;
            _repoAuditoria = repoAuditoria;
        }

        public void EditarUsuario(UsuarioDTO dto)
        {
            Usuario u = _repoUsuario.FindById((int)dto.Id);

            u.NombreCompleto = new NombreCompleto(dto.Nombre, dto.Apellido);
            u.Email = dto.Email;
            //u.Rol = dto.Rol;

            u.Validar();
            _repoUsuario.Update(u);

            Auditoria aud = new Auditoria(dto.LogueadoId, "EDIT", dto.GetType().Name, u.ToString(), "Usuario editado correctamente" + JsonSerializer.Serialize(dto));

            _repoAuditoria.Auditar(aud);

        }
    }
}

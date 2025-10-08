using Obligatorio.DTOs.DTOs.DTOUsuario;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUObtenerUsuarios : ICUObtenerUsuarios
    {
        private IRepositorioUsuario _repoUsuario;

        public CUObtenerUsuarios(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }

        public List<UsuarioDTO> ObtenerUsuarios()
        {
            List<Usuario> usuarios = _repoUsuario.FindAll();
            List<UsuarioDTO> ret = MapperUsuario.FromListUsuarioToListUsuarioDTO(usuarios);
            return ret;

        }
    }
}


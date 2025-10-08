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
    public class CUObtenerUsuario : ICUObtenerUsuario
    {
        private IRepositorioUsuario _repoUsuario;
        public CUObtenerUsuario(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }

        public UsuarioDTO ObtenerUsuario(int id)
        {
            Usuario b = _repoUsuario.FindById(id);
            UsuarioDTO dto = MapperUsuario.FromUsuarioToDTOUsuario(b);
            return dto;
        }
    }
}

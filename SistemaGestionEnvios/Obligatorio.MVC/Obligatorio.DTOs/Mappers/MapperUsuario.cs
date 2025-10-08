using Obligatorio.DTOs.DTOs.DTOUsuario;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Enumerados.UsuarioEnums;
using Obligatorio.LogicaNegocio.VO.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.Mappers
{
    public class MapperUsuario
    {
        public static Usuario FromDTOAltaUsuarioToUsuario(AltaUsuarioDTO dto)
        {

            var r = Roles.Administrador;

            if (dto.Rol.Equals(1))
            {
                r = Roles.Funcionario;
            }else if (dto.Rol.Equals(2))
            {
                r = Roles.Cliente;
            }

            string passHashed = Utilidades.Crypto.HashPasswordConBcrypt(dto.Password, 12);


            Usuario ret = new Usuario(new NombreCompleto(dto.Nombre, dto.Apellido), dto.Email, passHashed, r);

            return ret;

        }

        public static List<UsuarioDTO> FromListUsuarioToListUsuarioDTO(List<Usuario> usuarios)
        {
            List<UsuarioDTO> ret = new List<UsuarioDTO>();

            foreach (Usuario u in usuarios)
            {
                ret.Add(FromUsuarioToDTOUsuario(u));
            }

            return ret;
        }

        public static UsuarioDTO FromUsuarioToDTOUsuario(Usuario u)
        {
            return new UsuarioDTO() { Id = u.Id, Nombre = u.NombreCompleto.Nombre, Apellido = u.NombreCompleto.Apellido, Email = u.Email, Rol = u.Rol.ToString() };
        }
    }
}

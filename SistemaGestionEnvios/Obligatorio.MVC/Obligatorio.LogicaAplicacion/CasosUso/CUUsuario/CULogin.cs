using Obligatorio.DTOs.DTOs.DTOUsuario;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CULogin : ICULogin
    {
        private IRepositorioUsuario _repoUsuario;

        public CULogin(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }

        public UsuarioDTO VerificarDatosParaLogin(UsuarioDTO dto)
        {
            try
            {
                Usuario u = _repoUsuario.FindByEmail(dto.Email);

                bool coincideElPassword = Utilidades.Crypto.VerifyPasswordConBcrypt(dto.Password, u.Password);

                if (coincideElPassword)
                {
                    UsuarioDTO ret = new UsuarioDTO();
                    ret.Id = u.Id;
                    ret.Email = u.Email;
                    ret.Rol = u.Rol.ToString();
                    return ret;
                }
                else
                {
                    throw new BadLoginException();
                }
            }
            catch (Exception e)
            {
                throw e;
            }


        }

    }
}

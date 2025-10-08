using Obligatorio.DTOs.DTOs.DTOUsuario;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.CustomExceptions.EnvioExceptions;
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
    public class CUCambiarContrasenia : ICUCambiarContrasenia
    {
        private IRepositorioUsuario _repoUsuario;

        public CUCambiarContrasenia(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }
        public void Ejecutar(string email, CambiarContraseniaDTO dto)
        {
            Usuario u = _repoUsuario.FindByEmail(email);
            if (u == null)
            {
                throw new UsuarioNoEncontradoException("Cliente no encontrado.");
            }
            if (dto.AnteriorContrasenia == dto.NuevaContrasenia)
            {
                throw new PasswordIgualesException("La contraseña nueva es incorrecta.");
            }
            if (string.IsNullOrEmpty(dto.AnteriorContrasenia) || dto.NuevaContrasenia.Length < 8) { 
                    throw new PasswordNoValidoException("La nueva contraseña debe tener al menos 8 caracteres.");
            }
            bool coincideElPassword = Utilidades.Crypto.VerifyPasswordConBcrypt(dto.NuevaContrasenia, u.Password);
            if(coincideElPassword)
            {
                throw new PasswordIgualesException("La nueva contraseña no puede ser igual a la anterior.");
            }
            var nuevaHash = BCrypt.Net.BCrypt.HashPassword(dto.NuevaContrasenia);
            u.CambiarContrasenia(nuevaHash);
            _repoUsuario.Update(u);
        }
    }
}

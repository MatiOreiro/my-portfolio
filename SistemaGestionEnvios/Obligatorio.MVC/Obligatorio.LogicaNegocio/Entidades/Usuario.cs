using Obligatorio.LogicaNegocio.CustomExceptions;
using Obligatorio.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using Obligatorio.LogicaNegocio.Enumerados.UsuarioEnums;
using Obligatorio.LogicaNegocio.VO.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public NombreCompleto NombreCompleto { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Roles Rol { get; set; }


        public Usuario() { }

        public Usuario(NombreCompleto nombreCompleto, string email, string password, Roles rol)
        {
            NombreCompleto = nombreCompleto;
            Email = email;
            Password = password;
            Rol = rol;

            NombreCompleto.Validar();
            if (!email.Contains('@'))
            {
                throw new EmailNoValidoException("El email no tiene arroba");
            }
        }

        public void Validar()
        {
            if (NombreCompleto == null)
            {
                throw new NombreNoValidoException("El nombre completo no puede estar vacío");
            }
            if (string.IsNullOrEmpty(Email))
            {
                throw new EmailNoValidoException("El email no puede ser nulo o vacio");
            }
            if (string.IsNullOrEmpty(Password))
            {
                throw new PasswordNoValidoException("La contraseña no puede ser nula o vacia");
            }
        }

        public void CambiarContrasenia(string nuevaContrasenia)
        {
            Password = nuevaContrasenia;
        }
    }
}

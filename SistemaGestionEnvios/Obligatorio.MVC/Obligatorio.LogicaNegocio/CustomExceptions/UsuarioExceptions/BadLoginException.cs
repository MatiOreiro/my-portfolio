using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.UsuarioExceptions
{
    public class BadLoginException : Exception
    {
        public BadLoginException():base("Error de credenciales")
        {
        }
        public BadLoginException(string message) : base(message)
        {
        }
    }
}

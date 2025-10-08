using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.UsuarioExceptions
{
    public class EmailYaExisteException : Exception
    {
        public EmailYaExisteException(string message) : base(message)
        {
        }
    }
}

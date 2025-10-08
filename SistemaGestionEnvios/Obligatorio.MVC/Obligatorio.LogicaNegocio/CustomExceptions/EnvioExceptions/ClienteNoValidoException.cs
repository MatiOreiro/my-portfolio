using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.EnvioExceptions
{
    public class ClienteNoValidoException : Exception
    {
        public ClienteNoValidoException(string message) : base(message)
        {
        }
    }
}

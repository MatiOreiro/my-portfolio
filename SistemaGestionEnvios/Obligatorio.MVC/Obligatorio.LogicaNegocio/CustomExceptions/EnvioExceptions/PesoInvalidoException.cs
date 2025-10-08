using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.EnvioExceptions
{
    public class PesoInvalidoException : Exception
    {
        public PesoInvalidoException(string message) : base(message)
        {
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.SeguimientoExceptions
{
    public class ComentarioVacioException : Exception
    {
        public ComentarioVacioException(string message) : base(message)
        {
        }
    }
}

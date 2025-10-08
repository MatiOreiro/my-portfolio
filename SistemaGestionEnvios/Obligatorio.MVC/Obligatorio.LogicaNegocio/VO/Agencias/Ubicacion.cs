using Obligatorio.LogicaNegocio.CustomExceptions.AgenciaExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.VO.Agencias
{
    public record Ubicacion
    {
        public string Latitud { get; init; }
        public string Longitud { get; init; }

        public Ubicacion(string latitud, string longitud)
        {
            Latitud = latitud;
            Longitud = longitud;
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Latitud))
                throw new UbicacionNoValidaException("La latitud no puede estar vacía.");
            if (string.IsNullOrEmpty(Longitud))
                throw new UbicacionNoValidaException("La longitud no puede estar vacía.");
        }
    }
}

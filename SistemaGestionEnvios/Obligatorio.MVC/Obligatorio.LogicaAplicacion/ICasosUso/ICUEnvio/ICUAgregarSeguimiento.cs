using Obligatorio.DTOs.DTOs.DTOEnvio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.ICasosUso.ICUEnvio
{
    public interface ICUAgregarSeguimiento
    {
        void AgregarSeguimiento(AgregarSeguimientoDTO dto);
    }
}

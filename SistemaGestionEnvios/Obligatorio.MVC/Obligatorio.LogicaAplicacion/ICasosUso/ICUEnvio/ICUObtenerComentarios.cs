using Obligatorio.DTOs.DTOs.DTOSeguimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.ICasosUso.ICUEnvio
{
    public interface ICUObtenerComentarios
    {
        List<SeguimientoDTO> ObtenerComentarios(int id);
    }
}

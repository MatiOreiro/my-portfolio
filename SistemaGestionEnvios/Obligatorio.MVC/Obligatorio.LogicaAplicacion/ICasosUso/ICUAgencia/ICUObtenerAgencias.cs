using Obligatorio.DTOs.DTOs.DTOAgencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.ICasosUso.ICUAgencia
{
    public interface ICUObtenerAgencias
    {
        List<AgenciaDTO> ObtenerAgencias();
    }
}

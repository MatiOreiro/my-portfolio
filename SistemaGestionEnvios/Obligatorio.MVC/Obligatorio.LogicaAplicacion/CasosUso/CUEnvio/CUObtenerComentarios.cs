using Obligatorio.DTOs.DTOs.DTOSeguimiento;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUEnvio;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUEnvio
{
    public class CUObtenerComentarios : ICUObtenerComentarios
    {
        private IRepositorioEnvio _repoEnvio;
        public CUObtenerComentarios(IRepositorioEnvio repoEnvio)
        {
            _repoEnvio = repoEnvio;
        }
        public List<SeguimientoDTO> ObtenerComentarios(int id)
        {
            Envio envio = _repoEnvio.FindById(id);
            List<SeguimientoDTO> ret = MapperSeguimiento.FromListaSeguimientoToListaSeguimientoDTO(envio.Seguimiento);
            return ret;
        }
    }
}

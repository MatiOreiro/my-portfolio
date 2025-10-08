using Obligatorio.DTOs.DTOs.DTOEnvio;
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
    public class CUObtenerEnvioPorTracking : ICUObtenerEnvioPorTracking
    {
        private IRepositorioEnvio _repoEnvio;
        public CUObtenerEnvioPorTracking(IRepositorioEnvio repoEnvio)
        {
            _repoEnvio = repoEnvio;
        }
        public EnvioDTO ObtenerEnvioPorTracking(int nroTracking)
        {
            Envio e = _repoEnvio.FindByTracking(nroTracking);
            EnvioDTO dto = MapperEnvio.FromEnvioToEnvioDTO(e);
            return dto;
        }
    }
}

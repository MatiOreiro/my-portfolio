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
    public class CUObtenerEnvios : ICUObtenerEnvios
    {
        private IRepositorioEnvio _repoEnvio;
        public CUObtenerEnvios(IRepositorioEnvio repoEnvio)
        {
            _repoEnvio = repoEnvio;
        }
        public List<EnvioDTO> ObtenerEnvios()
        {
            List<Envio> envios = _repoEnvio.FindAll();
            List<EnvioDTO> ret = MapperEnvio.FromListEnvioToListEnvioDTO(envios);
            return ret;
        }
    }
}

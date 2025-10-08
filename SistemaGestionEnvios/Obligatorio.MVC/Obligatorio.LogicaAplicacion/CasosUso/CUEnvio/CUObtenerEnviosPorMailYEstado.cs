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
    public class CUObtenerEnviosPorMailYEstado : ICUObtenerEnviosPorMailYEstado
    {
        private IRepositorioEnvio _repoEnvio;
        public CUObtenerEnviosPorMailYEstado(IRepositorioEnvio repositorioEnvio)
        {
            _repoEnvio = repositorioEnvio;
        }
        public List<EnvioDTO> Ejecutar(string email, string estadoEnvio)
        {
            List<Envio> envios = _repoEnvio.FindByComentario(email, estadoEnvio);
            List<EnvioDTO> ret = MapperEnvio.FromListEnvioToListEnvioDTO(envios);
            return ret;
        }
    }
}

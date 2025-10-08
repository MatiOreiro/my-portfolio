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
    public class CUObtenerEnvio : ICUObtenerEnvio
    {
        private IRepositorioEnvio _repoEnvio;
        public CUObtenerEnvio(IRepositorioEnvio repoEnvio)
        {
            _repoEnvio = repoEnvio;
        }
        public EnvioDTO ObtenerEnvio(int id)
        {
            Envio e = _repoEnvio.FindById(id);
            EnvioDTO dto = MapperEnvio.FromEnvioToEnvioDTO(e);
            return dto;
        }
    }
}

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
    public class CUObtenerEnviosPorMail : ICUObtenerEnviosPorMail
    {
        private IRepositorioEnvio _repoEnvio;
        public CUObtenerEnviosPorMail(IRepositorioEnvio repoEnvio)
        {
            _repoEnvio = repoEnvio;
        }

        public List<EnvioDTO> Ejecutar(string mail)
        {
            List<Envio> e = _repoEnvio.FindByMail(mail);
            List<EnvioDTO> dto = MapperEnvio.FromListEnvioToListEnvioDTO(e);
            return dto;
        }
    }
}

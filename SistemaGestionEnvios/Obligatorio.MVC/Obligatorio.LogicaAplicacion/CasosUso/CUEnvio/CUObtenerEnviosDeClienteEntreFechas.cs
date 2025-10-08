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
    public class CUObtenerEnviosDeClienteEntreFechas : ICUObtenerEnviosDeClienteEntreFechas
    {
        private IRepositorioEnvio _repoEnvio;
        public CUObtenerEnviosDeClienteEntreFechas(IRepositorioEnvio repoEnvio)
        {
            _repoEnvio = repoEnvio;
        }
        public List<EnvioDTO> Ejecutar(string mail, DateTime fechaDesde, DateTime fechaHasta)
        {
            List<Envio> envios = _repoEnvio.FindByMailFechas(mail, fechaDesde, fechaHasta);
            List<EnvioDTO> ret = MapperEnvio.FromListEnvioToListEnvioDTO(envios);
            return ret;
        }
    }
}

using Obligatorio.DTOs.DTOs.DTOAgencia;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUAgencia;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUAgencia
{
    public class CUObtenerAgencias : ICUObtenerAgencias
    {
        private IRepositorioAgencia _repoAgencia;
        public CUObtenerAgencias(IRepositorioAgencia repoAgencia)
        {
            _repoAgencia = repoAgencia;
        }
        public List<AgenciaDTO> ObtenerAgencias()
        {
            List<Agencia> agencias = _repoAgencia.FindAll();
            List<AgenciaDTO> ret = MapperAgencia.FromListAgenciaToListAgenciaDTO(agencias);
            return ret;
        }
    }
}

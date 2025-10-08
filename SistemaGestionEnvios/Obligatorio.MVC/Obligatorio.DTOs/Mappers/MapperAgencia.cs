using Obligatorio.DTOs.DTOs.DTOAgencia;
using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.Mappers
{
    public class MapperAgencia
    {
        public static List<AgenciaDTO> FromListAgenciaToListAgenciaDTO(List<Agencia> agencias)
        {
            List<AgenciaDTO> ret = new List<AgenciaDTO>();
            foreach (var a in agencias)
            {
                ret.Add(FromAgenciaToAgenciaDTO(a));
            }
            return ret;
        }
        public static AgenciaDTO FromAgenciaToAgenciaDTO(Agencia agencia)
        {
            return new AgenciaDTO() { Id = agencia.Id ,Direccion = agencia.Direccion, Latitud = agencia.Ubicacion.Latitud.ToString(), Longitud = agencia.Ubicacion.Longitud.ToString(), Nombre = agencia.Nombre };

        }
    }
}

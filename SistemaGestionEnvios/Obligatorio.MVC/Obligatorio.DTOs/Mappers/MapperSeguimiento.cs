using Obligatorio.DTOs.DTOs.DTOEnvio;
using Obligatorio.DTOs.DTOs.DTOSeguimiento;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.Mappers
{
    public class MapperSeguimiento
    {
        public static Seguimiento FromAgregarSeguimientoDTOToSeguimiento(AgregarSeguimientoDTO dto)
        {
            Seguimiento s = new Seguimiento(null, dto.Comentario);
            return s;
        }
        public static SeguimientoDTO FromSeguimientoToSeguimientoDTO(Seguimiento seguimiento)
        {
            SeguimientoDTO dto = new SeguimientoDTO(seguimiento.Funcionario.NombreCompleto.Nombre + " " + seguimiento.Funcionario.NombreCompleto.Apellido, seguimiento.Comentario, seguimiento.Fecha);
            return dto;
        }

        public static List<SeguimientoDTO> FromListaSeguimientoToListaSeguimientoDTO(List<Seguimiento> seguimientos)
        {
            List<SeguimientoDTO> ret = new List<SeguimientoDTO>();
            foreach (Seguimiento s in seguimientos)
            {
                ret.Add(FromSeguimientoToSeguimientoDTO(s));
            }
            return ret;
        }
    }
}

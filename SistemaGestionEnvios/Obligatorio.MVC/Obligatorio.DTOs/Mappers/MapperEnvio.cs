using Obligatorio.DTOs.DTOs.DTOEnvio;
using Obligatorio.DTOs.DTOs.DTOSeguimiento;
using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.Mappers
{
    public class MapperEnvio
    {
        public static Envio FromAltaEnvioDTOToEnvio(AltaEnvioDTO dto)
        {
            Envio nuevo;
            if(dto.TipoEnvio.Equals("comun"))
            {
                nuevo = new Comun(0, null, null, dto.Peso, LogicaNegocio.Enumerados.EnvioEnums.EstadoEnvio.EN_PROCESO, null);
            }
            else
            {
                nuevo = new Urgente(0, null, null, dto.Peso, LogicaNegocio.Enumerados.EnvioEnums.EstadoEnvio.EN_PROCESO, dto.Direccion, null);
            }
            return nuevo;
        }
        public static EnvioDTO FromEnvioToEnvioDTO(Envio envio)
        {
            EnvioDTO dto;
            if(envio is Comun c)
            {
                dto = new EnvioDTO(envio.GetType().Name, envio.Id, envio.NroTracking, envio.Funcionario.Id, envio.Funcionario.NombreCompleto.Nombre + " " + envio.Funcionario.NombreCompleto.Apellido,
                    envio.Cliente.Id, envio.Cliente.NombreCompleto.Nombre + " " + envio.Cliente.NombreCompleto.Apellido, envio.Cliente.Email, envio.Peso, envio.Estado.ToString(), null, null);
            }
            else
            {
                Urgente u = envio as Urgente;
                dto = new EnvioDTO(envio.GetType().Name, envio.Id, envio.NroTracking, envio.Funcionario.Id, envio.Funcionario.NombreCompleto.Nombre + " " + envio.Funcionario.NombreCompleto.Apellido,
                    envio.Cliente.Id, envio.Cliente.NombreCompleto.Nombre + " " + envio.Cliente.NombreCompleto.Apellido, envio.Cliente.Email, envio.Peso, envio.Estado.ToString(), u.Direccion, u.Valor);
            }

            List<SeguimientoDTO> seguimientos = MapperSeguimiento.FromListaSeguimientoToListaSeguimientoDTO(envio.Seguimiento);
            dto.Seguimiento = seguimientos;
            return dto;
        }
        public static List<EnvioDTO> FromListEnvioToListEnvioDTO(List<Envio> envios)
        {
            List<EnvioDTO> ret = new List<EnvioDTO>();
            foreach (Envio e in envios)
            {
                List<SeguimientoDTO> seguimientos = MapperSeguimiento.FromListaSeguimientoToListaSeguimientoDTO(e.Seguimiento);
                EnvioDTO dto = FromEnvioToEnvioDTO(e);
                dto.Seguimiento = seguimientos;
                ret.Add(dto);
            }

            return ret;
        }
    }
}

using Obligatorio.DTOs.DTOs.DTOEnvio;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUEnvio;
using Obligatorio.LogicaNegocio.CustomExceptions.SeguimientoExceptions;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUEnvio
{
    public class CUAgregarSeguimiento : ICUAgregarSeguimiento
    {
        private IRepositorioEnvio _repoEnvio;
        private IRepositorioAuditoria _repoAuditoria;
        private IRepositorioUsuario _repoUsuario;
        public CUAgregarSeguimiento(IRepositorioEnvio repoEnvio, IRepositorioAuditoria repoAuditoria, IRepositorioUsuario repoUsuario)
        {
            _repoEnvio = repoEnvio;
            _repoAuditoria = repoAuditoria;
            _repoUsuario = repoUsuario;
        }
        public void AgregarSeguimiento(AgregarSeguimientoDTO dto)
        {
            if(dto.Comentario.Length == 0)
            {
                throw new ComentarioVacioException("El comentario no puede estar vacío");
            }
            else
            {
                Envio envio = _repoEnvio.FindById(dto.IdEnvio);
                Seguimiento s = MapperSeguimiento.FromAgregarSeguimientoDTOToSeguimiento(dto);
                Usuario funcionario = _repoUsuario.FindById(dto.LogueadoId);
                s.Funcionario = funcionario;
                envio.Seguimiento.Add(s);
                _repoEnvio.Update(envio);
                _repoAuditoria.Auditar(new Auditoria(dto.LogueadoId, "AGREGA", "SEGUIMIENTO", dto.IdEnvio.ToString(), JsonSerializer.Serialize(s)));
            }


        }
    }
}

using Obligatorio.DTOs.DTOs.DTOEnvio;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUEnvio;
using Obligatorio.LogicaNegocio.CustomExceptions.EnvioExceptions;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUEnvio
{
    public class CUAltaEnvio : ICUAltaEnvio
    {
        private IRepositorioEnvio _repoEnvio;
        private IRepositorioAgencia _repoAgencia;
        private IRepositorioUsuario _repoUsuario;
        private IRepositorioAuditoria _repoAuditoria;
        public CUAltaEnvio(IRepositorioEnvio repoEnvio, IRepositorioAgencia repoAgencia, IRepositorioUsuario repoUsuario, IRepositorioAuditoria repoAuditoria)
        {
            _repoEnvio = repoEnvio;
            _repoAgencia = repoAgencia;
            _repoUsuario = repoUsuario;
            _repoAuditoria = repoAuditoria;
        }

        public void AltaEnvio(AltaEnvioDTO dto)
        {
            try
            {
                if(dto.Peso <= 0)
                {
                    throw new PesoInvalidoException("El peso no puede ser menor o igual a cero");
                }
                else
                {
                    Agencia agencia = _repoAgencia.FindById(dto.IdAgencia);
                    Usuario funcionario = _repoUsuario.FindById(dto.IdFuncionario);
                    Usuario cliente = _repoUsuario.FindByEmail(dto.MailCliente);
                    if (cliente == null)
                    {
                        throw new ClienteNoValidoException("No se encontró al cliente");
                    }
                    else
                    {
                        Envio envio = MapperEnvio.FromAltaEnvioDTOToEnvio(dto);

                        if (dto.TipoEnvio.Equals("comun"))
                        {
                            Comun e = envio as Comun;
                            e.Agencia = agencia;
                        }

                        envio.Funcionario = funcionario;
                        envio.Cliente = cliente;
                        string nroTracking = DateTime.Now.ToString("MMddmmss") + dto.IdFuncionario;
                        envio.NroTracking = int.Parse(nroTracking);
                        envio.Seguimiento.Add(new Seguimiento(funcionario, "Envio creado"));

                        int idIns = _repoEnvio.Add(envio);

                        Auditoria aud = new Auditoria(dto.IdFuncionario, "ALTA", "ENVIO", idIns.ToString(), JsonSerializer.Serialize(envio));
                        _repoAuditoria.Auditar(aud);
                    }

                }

            }
            catch (Exception ex)
            {
                Auditoria aud = new Auditoria(dto.IdFuncionario, "ALTA", "ENVIO", null, ex.Message);
                _repoAuditoria.Auditar(aud);

                throw ex;
            }

        }
    }
}
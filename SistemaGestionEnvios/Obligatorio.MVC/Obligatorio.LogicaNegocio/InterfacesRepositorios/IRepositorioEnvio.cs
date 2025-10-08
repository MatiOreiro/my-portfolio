using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioEnvio : IRepositorio<Envio>
    {
        Envio FindByTracking(int nroTracking);

        List<Envio> FindByMail(string mail);

        List<Envio> FindByMailFechas(string mail, DateTime fechaDesde, DateTime fechaHasta);

        List<Envio> FindByComentario(string mail, string com);
    }
}

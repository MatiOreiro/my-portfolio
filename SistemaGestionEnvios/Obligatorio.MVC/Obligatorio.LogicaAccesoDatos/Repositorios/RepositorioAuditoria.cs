using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAccesoDatos.Repositorios
{
    public class RepositorioAuditoria : IRepositorioAuditoria
    {
        private ApplicationDbContext _context;
        public RepositorioAuditoria(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Auditar(Auditoria nueva)
        {
            _context.Auditorias.Add(nueva);
            _context.SaveChanges();
        }
    }
}

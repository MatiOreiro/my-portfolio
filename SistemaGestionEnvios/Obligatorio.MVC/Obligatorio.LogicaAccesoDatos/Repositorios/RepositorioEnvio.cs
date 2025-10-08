using Microsoft.EntityFrameworkCore;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAccesoDatos.Repositorios
{
    public class RepositorioEnvio : IRepositorioEnvio
    {
        private ApplicationDbContext _context;

        public RepositorioEnvio(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Add(Envio nuevo)
        {
            _context.Envios.Add(nuevo);
            _context.SaveChanges();
            return nuevo.Id;
        }

        public List<Envio> FindAll()
        {
            return _context.Envios.Include(a => a.Seguimiento).Include(e => e.Funcionario).Include(e => e.Cliente).ToList();
        }

        public Envio FindById(int id)
        {
            return _context.Envios.Include(a => a.Seguimiento).Include(a => a.Cliente).Include(a => a.Funcionario).Where(a => a.Id.Equals(id)).SingleOrDefault();
        }

        public void Remove(int id)
        {
            Envio e = _context.Envios.Where(x => x.Id == id).SingleOrDefault();
            _context.Envios.Remove(e);
            _context.SaveChanges();
        }

        public int Update(Envio obj)
        {
            _context.Envios.Update(obj);
            _context.SaveChanges();
            return obj.Id;
        }
        public Envio FindByTracking(int nroTracking)
        {
            return _context.Envios.Include(a => a.Seguimiento).Include(a => a.Cliente).Include(a => a.Funcionario).Where(a => a.NroTracking.Equals(nroTracking)).SingleOrDefault();
        }

        public List<Envio> FindByMail(string mail)
        {
            return _context.Envios.Include(a => a.Seguimiento)
                                  .Include(a => a.Cliente)
                                  .Include(a => a.Funcionario)
                                  .Where(a => a.Cliente.Email.Equals(mail))
                                  .ToList();
        }

        public List<Envio> FindByMailFechas(string mail, DateTime fechaDesde, DateTime fechaHasta)
        {
            return _context.Envios
                .Include(a => a.Seguimiento)
                .Include(a => a.Cliente)
                .Include(a => a.Funcionario)
                .Where(a => a.Cliente.Email == mail
                    && a.Seguimiento
                        .OrderBy(s => s.Fecha)
                        .Select(s => s.Fecha.Date)
                        .FirstOrDefault() >= fechaDesde
                    && a.Seguimiento
                        .OrderBy(s => s.Fecha)
                        .Select(s => s.Fecha.Date)
                        .FirstOrDefault() <= fechaHasta)
                .OrderBy(a => a.NroTracking)
                .ToList();
        }

        public List<Envio> FindByComentario(string mail, string com)
        {
            return _context.Envios
                .Include(a => a.Seguimiento)
                .Include(a => a.Cliente)
                .Include(a => a.Funcionario)
                .Where(a => a.Cliente.Email == mail 
                    && a.Seguimiento.Any(s => s.Comentario.Contains(com)))
                .OrderBy(a => a.Seguimiento.Min(s => s.Fecha))
                .ToList();
        }
    }
}

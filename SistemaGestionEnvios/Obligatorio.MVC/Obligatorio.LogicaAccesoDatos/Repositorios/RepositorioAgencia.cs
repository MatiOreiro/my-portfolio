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
    public class RepositorioAgencia : IRepositorioAgencia
    {
        private ApplicationDbContext _context;

        public RepositorioAgencia(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Add(Agencia nuevo)
        {
            _context.Entry(nuevo.Ubicacion).State = EntityState.Unchanged;
            _context.Agencias.Add(nuevo);
            _context.SaveChanges();
            return nuevo.Id;
        }

        public List<Agencia> FindAll()
        {
            return _context.Agencias
                .Include(a => a.Ubicacion)
                .ToList();
        }

        public Agencia FindById(int id)
        {
            return _context.Agencias.Include(a => a.Ubicacion).Where(a => a.Id.Equals(id)).SingleOrDefault();
        }

        public void Remove(int id)
        {
            Agencia b = _context.Agencias.Where(x => x.Id == id).SingleOrDefault();
            _context.Agencias.Remove(b);
            _context.SaveChanges();
        }

        public int Update(Agencia obj)
        {
            _context.Agencias.Update(obj);
            _context.SaveChanges();
            return obj.Id;
        }
    }
}

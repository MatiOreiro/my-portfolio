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
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private ApplicationDbContext _context;
        public RepositorioUsuario(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Add(Usuario nuevo)
        {
           // _context.Entry(nuevo.NombreCompleto).State = EntityState.Unchanged;
            _context.Usuarios.Add(nuevo);
            _context.SaveChanges();
            return nuevo.Id;
        }
        public List<Usuario> FindAll()
        {
            return _context.Usuarios.Include(x => x.NombreCompleto).ToList();
        }
        public Usuario FindById(int id)
        {
            return _context.Usuarios.Include(a => a.NombreCompleto).Where(a => a.Id.Equals(id)).SingleOrDefault();
        }

        public Usuario FindByEmail(string email)
        {
            return _context.Usuarios.Include(a => a.NombreCompleto).Where(a => a.Email.Equals(email)).SingleOrDefault();
        }
        public void Remove(int id)
        {
            Usuario b = _context.Usuarios.Where(x => x.Id == id).SingleOrDefault();
            _context.Usuarios.Remove(b);
            _context.SaveChanges();
        }
        public int Update(Usuario obj)
        {
            _context.Usuarios.Update(obj);
            _context.SaveChanges();
            return obj.Id;
        }
    }
    
}

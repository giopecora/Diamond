using Diamond.Domain.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Diamond.Repository.Repository
{
    public class UsuarioRepository
    {
        private DiamondContext _context = new DiamondContext();

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuarios;
        }

        public Usuario GetById(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public Usuario Insert(Usuario entity)
        {
            _context.Usuarios.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public bool Update(Usuario entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }

            return true;
        }

        public bool Delete(int id)
        {
            Usuario entity = GetById(id);

            _context.Usuarios.Remove(entity);
            return _context.SaveChanges() > 0;
        }
    }
}

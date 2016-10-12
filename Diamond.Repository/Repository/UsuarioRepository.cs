using Diamond.Domain.DTO.Result;
using Diamond.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Result<bool> Update(int id, Usuario entity)
        {
            Result<bool> result = new Result<bool>();

            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!UsuarioExists(id))
                {
                    return result.SetError(ex);
                }
                else
                {
                    throw;
                }
            }

            return result.SetData(true);
        }

        public bool Delete(int id)
        {
            Usuario entity = GetById(id);

            _context.Usuarios.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Count(e => e.ID_Usuario == id) > 0;
        }
    }
}

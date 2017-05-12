using Diamond.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Repository
{
    public class CartaoRepository
    {
        private DiamondContext _context = new DiamondContext();

        public Cartao GetById(int id)
        {
            return _context.Cartoes.Find(id);
        }

        public List<Cartao> GetAllFromUser(int userId)
        {
            return _context.Cartoes.Where(u => u.UsuarioId == userId).ToList();
        }

        public Cartao Insert(Cartao entity)
        {
            _context.Cartoes.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public bool Update(Cartao entity)
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
            Cartao entity = GetById(id);

            _context.Cartoes.Remove(entity);
            return _context.SaveChanges() > 0;
        }
    }
}

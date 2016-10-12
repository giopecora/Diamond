using Diamond.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Repository.Repository
{
    public class PedidoRepository
    {
        private DiamondContext _context = new DiamondContext();

        public IEnumerable<Pedido> GetAllByUser(int userId)
        {
            return _context.Pedidos.Where(p => p.ID_Usuario == userId);
        }

        public Pedido GetById(int id)
        {
            return _context.Pedidos.Find(id);
        }

        public Pedido Insert(Pedido entity)
        {
            _context.Pedidos.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public bool Delete(int id)
        {
            Pedido entity = GetById(id);

            _context.Pedidos.Remove(entity);
            return _context.SaveChanges() > 0;
        }
    }
}

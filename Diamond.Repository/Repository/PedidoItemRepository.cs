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
    public class PedidoItemRepository
    {
        private DiamondContext _context = new DiamondContext();

        public IEnumerable<Pedido_Item> GetAllFromPedido(int pedidoId)
        {
            return _context.PedidoItens.Where(pi => pi.Id == pedidoId);
        }

        public Pedido_Item GetById(int id)
        {
            return _context.PedidoItens.Find(id);
        }

        public Pedido_Item Insert(Pedido_Item entity)
        {
            _context.PedidoItens.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public bool Update(int id, Pedido_Item entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw;
            }

            return true;
        }

        public bool Delete(int id)
        {
            Pedido_Item entity = GetById(id);

            _context.PedidoItens.Remove(entity);
            return _context.SaveChanges() > 0;
        }
    }
}

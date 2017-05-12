using Diamond.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Diamond.Repository
{
    public class PedidoItemRepository
    {
        private DiamondContext _context = new DiamondContext();

        public IEnumerable<Pedido_Itens> GetAllFromPedido(int pedidoId)
        {
            return _context.Pedido_Itens.Where(pi => pi.Id == pedidoId);
        }

        public Pedido_Itens GetById(int id)
        {
            return _context.Pedido_Itens.Find(id);
        }

        public Pedido_Itens Insert(Pedido_Itens entity)
        {
            _context.Pedido_Itens.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public bool Update(Pedido_Itens entity)
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
            Pedido_Itens entity = GetById(id);

            _context.Pedido_Itens.Remove(entity);
            return _context.SaveChanges() > 0;
        }
    }
}

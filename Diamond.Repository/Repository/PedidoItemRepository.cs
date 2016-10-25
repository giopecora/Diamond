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
            return _context.PedidosItens.Where(pi => pi.Id == pedidoId);
        }

        public Pedido_Item GetById(int id)
        {
            return _context.PedidosItens.Find(id);
        }

        public Pedido_Item Insert(Pedido_Item entity)
        {
            _context.PedidosItens.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public Result<bool> Update(int id, Pedido_Item entity)
        {
            Result<bool> result = new Result<bool>();

            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!PedidoItemExists(id))
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
            Pedido_Item entity = GetById(id);

            _context.PedidosItens.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        private bool PedidoItemExists(int id)
        {
            return _context.PedidosItens.Count(e => e.Id == id) > 0;
        }
    }
}

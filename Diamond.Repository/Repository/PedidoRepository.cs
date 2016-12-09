using Diamond.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Repository.Repository
{
    public class PedidoRepository : BaseRepository
    {
        private DiamondContext _context = new DiamondContext();

        public IEnumerable<Pedido> GetAllFromUser(int page)
        {
            int take = 10;
            int skip = (page - 1) * take;
            return _context.Pedidos.Include("Pedido_Itens").Where(p => p.UsuarioId == UserId)
                .OrderBy(p => p.Id)
                .Skip(skip)
                .Take(take);
        }

        public Pedido GetById(int id)
        {
            return _context.Pedidos.Include("Pedido_Itens").Where(p => p.Id == id && p.UsuarioId == UserId).FirstOrDefault();
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

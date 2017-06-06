using Diamond.Domain.DTO.Pedido;
using Diamond.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Repository
{
    public class PedidoRepository
    {
        private DiamondContext _context = new DiamondContext();

        public IEnumerable<Pedido> GetAllFromUser(int userId, int page)
        {
            int take = 10;
            int skip = (page - 1) * take;
            return _context.Pedidos.Include("Pedido_Itens").Where(p => p.UsuarioId == userId)
                .OrderBy(p => p.Id)
                .Skip(skip)
                .Take(take);
        }

        public PedidoDetalheDTO GetDetail(int pedidoId)
        {
            PedidoDetalheDTO detalhe =
                (from p in _context.Pedidos
                 join c in _context.Cartoes on p.CartaoId equals c.Id
                 join e in _context.Enderecos on p.EnderecoId equals e.Id
                 where p.Id == pedidoId
                 select new PedidoDetalheDTO()
                 {
                     NumeroCartao = c.Numero,
                     Endereco = e.Logradouro,
                     Itens = 
                     (from pi in _context.Pedido_Itens
                      join pr in _context.Produtos on pi.ProdutoId equals pr.Id
                      where pi.PedidoId == pedidoId
                      select new PedidoItemDetalheDTO()
                      {
                          Produto = pr.Nome,
                          Quantidade = pi.Quantidade,
                          ValorTotal = pi.ValorTotal
                      })
                 }).FirstOrDefault();

            return detalhe;
        }

        public Pedido GetById(int id)
        {
            return _context.Pedidos.Include("Pedido_Itens").Where(p => p.Id == id).FirstOrDefault();
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

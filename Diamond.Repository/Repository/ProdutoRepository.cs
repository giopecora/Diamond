using Diamond.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Repository.Repository
{
    public class ProdutoRepository
    {
        private DiamondContext _context = new DiamondContext();

        public IEnumerable<Produto> GetAllProducts()
        {
            return _context.Produto;
        }

        public IEnumerable<Produto> GetAllProductsByCategoryId(int categoryId)
        {
            return _context.Produto.Where(p => p.id_Categoria == categoryId);
        }

        public Produto InsertProduct(Produto entity)
        {
            _context.Produto.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public Produto GetProdutctById(int id)
        {
            return _context.Produto.Find(id);
        }
    }
}

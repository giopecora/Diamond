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
    public class ProdutoImagemRepository
    {
        private DiamondContext _context = new DiamondContext();

        public List<Produto_Imagens> ListImagesByProductId(int productId)
        {
            return _context.ProdutoImagens.Where(pi => pi.ProdutoId == productId).ToList();
        }

        public Produto_Imagens GetByProductIdAndName(int produtoId, string name)
        {
            return _context.ProdutoImagens.Where(pi => pi.ProdutoId == produtoId && pi.Imagem == name).FirstOrDefault();
        }

        public bool Update(Produto_Imagens entity)
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

        public bool Delete(Produto_Imagens entity)
        {
            _context.ProdutoImagens.Remove(entity);
            return _context.SaveChanges() > 0;
        }
    }
}

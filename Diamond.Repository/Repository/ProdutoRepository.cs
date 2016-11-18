using Diamond.Domain.DTO;
using Diamond.Domain.DTO.Result;
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
    public class ProdutoRepository
    {
        private DiamondContext _context = new DiamondContext();

        public List<ProdutoDestaqueDTO> GetTop5()
        {
            return _context.Database.SqlQuery<ProdutoDestaqueDTO>("EXEC sp_list_top_5_sells").ToList();
        }

        public List<ProdutoDestaqueDTO> GetTop4OfAllCategories()
        {
            return _context.Database.SqlQuery<ProdutoDestaqueDTO>("EXEC sp_list_top_4_sells_of_every_category").ToList();
        }

        public List<Produto> GetTop3CheaperByCategory(int categoryId)
        {
            return _context.Database.SqlQuery<Produto>($"EXEC sp_list_most_cheaper_product_by_category {categoryId}").ToList();
        }

        public IEnumerable<Produto> GetAll()
        {
            return _context.Produtos;
        }

        public IEnumerable<Produto> GetAllByCategoryId(int categoryId)
        {
            return _context.Produtos.Where(p => p.Id == categoryId);
        }

        public Produto GetById(int id)
        {
            return _context.Produtos.Find(id);
        }

        public Produto Insert(Produto entity)
        {
            _context.Produtos.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public bool Update(int id, Produto entity)
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
    }
}

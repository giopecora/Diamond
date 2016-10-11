using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diamond.Repository;
using Diamond.Domain.DTO.Result;
using Diamond.Domain.Entities;
using Diamond.Domain.DTO;

namespace Diamond.Business
{
    public class ProdutoBusiness
    {
        private ProdutoRepository _repository = new ProdutoRepository();

        public Result<List<ProdutoDTO>> GetAll()
        {
            Result<List<ProdutoDTO>> result = new Result<List<ProdutoDTO>>();
            List<ProdutoDTO> produtos = new List<ProdutoDTO>();

            return result.SetData(produtos);
        }

        //public IEnumerable<Produto> GetAllByCategoryId(int categoryId)
        //{
        //    return _context.Produto.Where(p => p.id_Categoria == categoryId);
        //}

        //public Produto GetById(int id)
        //{
        //    return _context.Produto.Find(id);
        //}

        //public Produto Insert(Produto entity)
        //{
        //    _context.Produto.Add(entity);
        //    _context.SaveChanges();

        //    return entity;
        //}

        //public Result<bool> Update(int id, Produto entity)
        //{
        //    Result<bool> result = new Result<bool>();

        //    _context.Entry(entity).State = EntityState.Modified;

        //    try
        //    {
        //        _context.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException ex)
        //    {
        //        if (!ProdutoExists(id))
        //        {
        //            return result.SetError(ex);
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return result.SetData(true);
        //}

        //public bool Delete(int id)
        //{
        //    Produto entity = GetById(id);

        //    _context.Produto.Remove(entity);
        //    return _context.SaveChanges() > 0;
        //}
    }
}

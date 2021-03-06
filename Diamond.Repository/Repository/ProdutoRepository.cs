﻿using Diamond.Domain.DTO;
using Diamond.Domain.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Diamond.Repository
{
    public class ProdutoRepository
    {
        private DiamondContext _context = new DiamondContext();

        public List<Produto> SearchForProducts(string search)
        {
            return _context.Database.SqlQuery<Produto>($"EXEC [dbo].[sp_list_products_by_search] {search}").ToList();
        }

        public List<ProdutoDestaqueDTO> GetTop5()
        {
            return _context.Database.SqlQuery<ProdutoDestaqueDTO>("EXEC sp_list_top_5_sells").ToList();
        }

        public List<Produto> GetTop3CheaperByCategory(int categoryId)
        {
            return _context.Database.SqlQuery<Produto>($"EXEC sp_list_most_cheaper_product_by_category {categoryId}").ToList();
        }

        public IEnumerable<Produto> GetAll(string query, int page)
        {
            int take = 10;
            int skip = (page - 1) * take;
            return _context.Produtos
                .OrderBy(p => p.Id)
                .Skip(skip)
                .Take(take);
        }

        public IEnumerable<Produto> ListAll(int page)
        {
            int take = 10;
            int skip = page == 0 ? 0 : (page - 1) * take;
            return _context.Produtos.Where(p => p.Ativo == true)
                .OrderBy(p => p.Id)
                .Skip(skip)
                .Take(take);
        }

        public IEnumerable<Produto> ListAllByName(int page, string name)
        {
            int take = 10;
            int skip = page == 0 ? 0 : (page - 1) * take;
            return _context.Produtos.Where(p => p.Ativo == true && p.Nome.ToLower().Contains(name.ToLower()))
                .OrderBy(p => p.Id)
                .Skip(skip)
                .Take(take);
        }

        public IEnumerable<Produto> GetAllByCategoryId(int categoryId, int page)
        {
            int take = 10;
            int skip = (page - 1) * take;
            return _context.Produtos.Where(p => p.CategoriaId == categoryId)
                .OrderBy(p => p.Id)
                .Skip(skip)
                .Take(take);
        }

        public int GetCount()
        {
            return _context.Produtos.Where(p => p.Ativo == true).Count();
        }

        public int GetCountByName(string name)
        {
            return _context.Produtos.Where(p => p.Ativo == true && p.Nome.ToLower().Contains(name.ToLower())).Count();
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

        public bool Update(Produto entity)
        {
            var local = _context.Set<Produto>().Local.FirstOrDefault(e => e.Id == entity.Id);
            if (local != null)            
                _context.Entry(local).State = EntityState.Detached;
            
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
    }
}


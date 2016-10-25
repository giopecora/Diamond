﻿using Diamond.Domain.DTO.Result;
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

        public Result<bool> Update(int id, Produto entity)
        {
            Result<bool> result = new Result<bool>();

            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!ProdutoExists(id))
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

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Count(e => e.Id == id) > 0;
        }
    }
}

﻿using Diamond.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Repository
{
    public class ProdutoImagemRepository
    {
        private DiamondContext _context = new DiamondContext();

        public List<Produto_Imagens> ListImagesByProductId(int productId)
        {
            return _context.Produto_Imagens.Where(pi => pi.ProdutoId == productId).ToList();
        }

        public Produto_Imagens GetByProductIdAndName(int produtoId, string name)
        {
            return _context.Produto_Imagens.Where(pi => pi.ProdutoId == produtoId && pi.Imagem == name).FirstOrDefault();
        }

        public bool Insert(Produto_Imagens entity)
        {
            _context.Produto_Imagens.Add(entity);
            return _context.SaveChanges() > 0;
        }

        public bool InsertRange(List<Produto_Imagens> entities)
        {
            _context.Produto_Imagens.AddRange(entities);
            return _context.SaveChanges() > 0;
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
            _context.Produto_Imagens.Remove(entity);
            return _context.SaveChanges() > 0;
        }
    }
}

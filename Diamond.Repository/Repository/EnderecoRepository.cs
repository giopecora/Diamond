﻿using Diamond.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Diamond.Repository.Repository
{
    public class EnderecoRepository
    {
        private DiamondContext _context = new DiamondContext();

        public Endereco GetById(int id)
        {
            return _context.Enderecos.Find(id);
        }

        public Endereco Insert(Endereco entity)
        {
            _context.Enderecos.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public bool Update(Endereco entity)
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

        public bool Delete(int id)
        {
            Endereco entity = GetById(id);

            _context.Enderecos.Remove(entity);
            return _context.SaveChanges() > 0;
        }
    }
}

﻿using Diamond.Domain.DTO.Result;
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

        public bool Update(int id, Endereco entity)
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

        public bool Delete(int id)
        {
            Endereco entity = GetById(id);

            _context.Enderecos.Remove(entity);
            return _context.SaveChanges() > 0;
        }
    }
}

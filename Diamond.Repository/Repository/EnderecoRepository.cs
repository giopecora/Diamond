using Diamond.Domain.DTO.Result;
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

        public Result<bool> Update(int id, Endereco entity)
        {
            Result<bool> result = new Result<bool>();

            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!EnderecoExists(id))
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

        public bool Delete(int id)
        {
            Endereco entity = GetById(id);

            _context.Enderecos.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        private bool EnderecoExists(int id)
        {
            return _context.Enderecos.Count(e => e.ID_Endereco == id) > 0;
        }
    }
}

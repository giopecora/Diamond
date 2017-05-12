using Diamond.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Repository
{
    public class EstoqueSaidaRepository
    {
        private DiamondContext _context = new DiamondContext();

        public int Insert(Estoque_Saida entity)
        {
            _context.Estoque_Saida.Add(entity);
            _context.SaveChanges();

            return entity.Id;
        }
    }
}

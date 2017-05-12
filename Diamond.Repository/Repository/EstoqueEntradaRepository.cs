using Diamond.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Repository
{
    public class EstoqueEntradaRepository
    {
        private DiamondContext _context = new DiamondContext();

        public int Insert(Estoque_Entrada entity)
        {
            _context.Estoque_Entrada.Add(entity);
            _context.SaveChanges();

            return entity.Id;
        }
    }
}

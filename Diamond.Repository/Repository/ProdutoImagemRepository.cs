using Diamond.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Repository.Repository
{
    public class ProdutoImagemRepository
    {
        private DiamondContext _context = new DiamondContext();

        public List<Produto_Imagens> ListImagesByProductId(int productId)
        {
            return _context.ProdutoImagens.Where(pi => pi.ProdutoId == productId).ToList();
        }
    }
}

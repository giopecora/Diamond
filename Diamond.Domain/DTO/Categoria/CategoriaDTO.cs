using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Domain.DTO
{
    public class CategoriaDTO
    {
        public CategoriaDTO()
        {
            Produtos = new List<ProdutoDTO>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual List<ProdutoDTO> Produtos { get; set; }
    }
}

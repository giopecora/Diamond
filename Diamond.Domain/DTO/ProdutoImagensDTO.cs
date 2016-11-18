using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Domain.DTO
{
    public class ProdutoImagensDTO
    {
        public ProdutoImagensDTO()
        {

        }

        public int ProdutoId { get; set; }
        public bool? Principal { get; set; }
        public string Imagem { get; set; }
    }
}

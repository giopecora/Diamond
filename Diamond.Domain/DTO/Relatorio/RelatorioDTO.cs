using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Domain.DTO
{
    public class RelatorioDTO
    {
        public int MovimentacaoId { get; set; }
        public string Produto { get; set; }
        public string Categoria { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public double ValorUnitario { get; set; }
        public double ValorTotal { get; set; }
        public DateTime DataMovimentacao { get; set; }
    }
}

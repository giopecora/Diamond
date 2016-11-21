using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Domain.DTO.Categoria
{
    public class ProdutoCategoria
    {
        public int Id { get; set; }
		public int ProdutoId { get; set; }
		public int MarcaId { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public double Preco { get; set; }
		public string ImagemPrincipal { get; set; }
		public int Compras { get; set; }
    }
}

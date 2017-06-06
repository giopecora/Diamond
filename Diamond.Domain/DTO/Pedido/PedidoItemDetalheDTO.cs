using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Domain.DTO.Pedido
{
    public class PedidoItemDetalheDTO
    {
        public string Produto { get; set; }
        public int Quantidade { get; set; }
        public double ValorTotal { get; set; }
    }
}

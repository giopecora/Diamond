using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Domain.DTO.Pedido
{
    public class PedidoDetalheDTO
    {
        public PedidoDetalheDTO()
        {
            Itens = new List<PedidoItemDetalheDTO>();
        }

        public string NumeroCartao { get; set; }
        public string Endereco { get; set; }

        public IEnumerable<PedidoItemDetalheDTO> Itens { get; set; }
    }
}

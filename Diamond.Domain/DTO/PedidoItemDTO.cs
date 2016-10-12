using Diamond.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Domain.DTO
{
    public class PedidoItemDTO
    {
        public PedidoItemDTO()
        {

        }

        public PedidoItemDTO(Pedido_Item entity)
        {
            Id = entity.ID_Pedido_Item;
            ProdutoId = entity.ID_Produto;
            PedidoId = entity.ID_Pedido;
            Quantidade = entity.NR_quantidade;
            ValorUnitarioTotal = entity.VL_unitario_total;
        }

        public Pedido_Item ToEntity()
        {
            return new Pedido_Item()
            {
                ID_Pedido_Item = Id,
                ID_Produto = ProdutoId,
                ID_Pedido = PedidoId,
                NR_quantidade = Quantidade,
                VL_unitario_total = ValorUnitarioTotal
            };
        }

        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int PedidoId { get; set; }
        public int? Quantidade { get; set; }
        public double? ValorUnitarioTotal { get; set; }
    }
}

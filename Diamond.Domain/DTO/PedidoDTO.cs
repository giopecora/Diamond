using Diamond.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Domain.DTO
{
    public class PedidoDTO
    {
        public PedidoDTO()
        {

        }

        public PedidoDTO(Pedido entity)
        {
            Id = entity.ID_Pedido;
            UsuarioId = entity.ID_Usuario;
            DataPedido = entity.DT_pedido;
            ValorTotal = entity.VL_total;
        }

        public Pedido ToEntity()
        {
            return new Pedido()
            {
                ID_Pedido = Id,
                ID_Usuario = UsuarioId,
                DT_pedido = DataPedido,
                VL_total = ValorTotal
            };
        }

        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public DateTime? DataPedido { get; set; }
        public double? ValorTotal { get; set; }
    }
}

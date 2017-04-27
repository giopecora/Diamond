using Diamond.Domain.Entities;
using Diamond.Utils.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Domain.DTO
{
    public class PedidoDTO
    {
        public PedidoDTO()
        {
            DataPedido = DateTime.Now;
        }

        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int CartaoId { get; set; }
        public int EnderecoId { get; set; }
        public DateTime? DataPedido { get; set; }
        public double? ValorTotal { get; set; }

        [JsonProperty("itens")]
        public List<PedidoItemDTO> Pedido_Itens { get; set; }

        public string DataPedidoFormatada
        {
            get
            {
                return DataPedido.Format(DateTimeFormatEnum.Presentation);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Domain.DTO
{
    public class EstoqueSaidaDTO : EstoqueDTO
    {
        public EstoqueSaidaDTO()
        {
            DataSaida = DateTime.UtcNow;
        }

        public int PedidoItemId { get; set; }
        public DateTime DataSaida { get; set; }
    }
}

namespace Diamond.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Estoque_Saida
    {
        public int Id { get; set; }

        public int ProdutoId { get; set; }

        public int? PedidoItemId { get; set; }

        public int? Quantidade { get; set; }

        public double? ValorUnitario { get; set; }

        public double? ValorTotal { get; set; }

        public DateTime? DataSaida { get; set; }

        public virtual Pedido_Itens Pedido_Itens { get; set; }

        public virtual Produto Produto { get; set; }
    }
}

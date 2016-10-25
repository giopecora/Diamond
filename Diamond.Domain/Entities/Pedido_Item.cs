namespace Diamond.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Pedido_Item
    {
        public int Id { get; set; }

        public int ProdutoId { get; set; }

        public int PedidoId { get; set; }

        public int? Quantidade { get; set; }

        public double? ValorUnitarioTotal { get; set; }

        public virtual Pedido Pedido { get; set; }

        public virtual Produto Produto { get; set; }
    }
}

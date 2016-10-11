namespace Diamond.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Pedido_Item
    {
        [Key]
        public int id_Pedido_Item { get; set; }

        public int id_Produto { get; set; }

        public int id_Pedido { get; set; }

        public int? nr_quantidade { get; set; }

        public double? vl_unitario_total { get; set; }

        public virtual Pedido Pedido { get; set; }

        public virtual Produto Produto { get; set; }
    }
}

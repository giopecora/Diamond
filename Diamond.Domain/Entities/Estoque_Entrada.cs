namespace Diamond.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Estoque_Entrada
    {
        [Key]
        public int id_Estoque_Entrada { get; set; }

        public int id_Produto { get; set; }

        public int? nr_Quantidade { get; set; }

        public DateTime? dt_entrada { get; set; }

        public virtual Produto Produto { get; set; }
    }
}

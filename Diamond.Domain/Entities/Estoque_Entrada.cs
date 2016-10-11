namespace Diamond.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Estoque_Entrada
    {
        [Key]
        public int ID_Estoque_Entrada { get; set; }

        public int ID_Produto { get; set; }

        public int? NR_Quantidade { get; set; }

        public DateTime? DT_entrada { get; set; }

        public virtual Produto Produto { get; set; }
    }
}

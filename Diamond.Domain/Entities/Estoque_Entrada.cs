namespace Diamond.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Estoque_Entrada
    {
        public int Id { get; set; }

        public int ProdutoId { get; set; }

        public int Quantidade { get; set; }

        public double ValorUnitario { get; set; }

        public double ValorTotal { get; set; }

        public DateTime DataEntrada { get; set; }

        public virtual Produto Produto { get; set; }
    }
}

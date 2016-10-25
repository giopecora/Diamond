namespace Diamond.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Produto_Imagens
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProdutoId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string Imagem { get; set; }

        public bool? Principal { get; set; }
    }
}

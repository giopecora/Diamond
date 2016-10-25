namespace Diamond.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Marca")]
    public partial class Marca
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Nome { get; set; }

        [StringLength(150)]
        public string Descricao { get; set; }

        [StringLength(150)]
        public string Imagem { get; set; }
    }
}

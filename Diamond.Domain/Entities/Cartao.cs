namespace Diamond.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Cartao")]
    public partial class Cartao
    {
        public int Id { get; set; }

        public int? UsuarioId { get; set; }

        public int? BandeiraId { get; set; }

        [StringLength(50)]
        public string Numero { get; set; }

        [StringLength(50)]
        public string Nome { get; set; }

        [StringLength(20)]
        public string Vencimento { get; set; }

        [StringLength(20)]
        public string CCR { get; set; }

        public virtual Bandeira Bandeira { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}

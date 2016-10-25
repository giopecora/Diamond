namespace Diamond.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Perfil")]
    public partial class Perfil
    {
        public int Id { get; set; }

        [StringLength(30)]
        public string Nome { get; set; }
    }
}

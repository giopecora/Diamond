namespace Diamond.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Perfil")]
    public partial class Perfil
    {
        [Key]
        public int id_Perfil { get; set; }

        [StringLength(30)]
        public string nm_Perfil { get; set; }
    }
}

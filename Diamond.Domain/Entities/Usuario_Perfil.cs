namespace Diamond.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Usuario_Perfil
    {
        [Key]
        [Column(Order = 0)]
        public int ID_Usuario { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Perfil { get; set; }

        public bool? FL_ativo { get; set; }
    }
}

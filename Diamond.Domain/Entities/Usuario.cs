namespace Diamond.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            Pedidoes = new HashSet<Pedido>();
            Enderecoes = new HashSet<Endereco>();
        }

        [Key]
        public int ID_Usuario { get; set; }

        [StringLength(120)]
        public string NM_Usuario { get; set; }

        [StringLength(50)]
        public string NM_login { get; set; }

        [StringLength(50)]
        public string DS_senha { get; set; }

        public bool? FL_Ativo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedido> Pedidoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Endereco> Enderecoes { get; set; }
    }
}

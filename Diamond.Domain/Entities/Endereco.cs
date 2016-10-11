namespace Diamond.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Endereco")]
    public partial class Endereco
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Endereco()
        {
            Usuarios = new HashSet<Usuario>();
        }

        [Key]
        public int ID_Endereco { get; set; }

        [StringLength(20)]
        public string NM_Logradouro { get; set; }

        [StringLength(100)]
        public string NM_Endereco { get; set; }

        public int? NR_Endereco { get; set; }

        [StringLength(50)]
        public string DS_Complemento { get; set; }

        [StringLength(7)]
        public string NR_CEP { get; set; }

        [StringLength(40)]
        public string NM_Cidade { get; set; }

        [StringLength(2)]
        public string DS_Sigla { get; set; }

        public int? NR_Tipo_Endereco { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}

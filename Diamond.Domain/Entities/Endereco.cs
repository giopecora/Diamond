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
            Usuario = new HashSet<Usuario>();
        }

        [Key]
        public int id_Endereco { get; set; }

        [StringLength(20)]
        public string nm_Logradouro { get; set; }

        [StringLength(100)]
        public string nm_Endereco { get; set; }

        public int? nr_Endereco { get; set; }

        [StringLength(50)]
        public string ds_Complemento { get; set; }

        [StringLength(7)]
        public string nr_CEP { get; set; }

        [StringLength(40)]
        public string nm_Cidade { get; set; }

        [StringLength(2)]
        public string ds_Sigla { get; set; }

        public int? nr_Tipo_Endereco { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}

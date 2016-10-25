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

        public int Id { get; set; }

        [StringLength(20)]
        public string Logradouro { get; set; }

        [StringLength(100)]
        public string Nome { get; set; }

        public int? Numero { get; set; }

        [StringLength(50)]
        public string Complemento { get; set; }

        [StringLength(7)]
        public string CEP { get; set; }

        [StringLength(40)]
        public string Cidade { get; set; }

        [StringLength(2)]
        public string Sigla { get; set; }

        public int? TipoEndereco { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}

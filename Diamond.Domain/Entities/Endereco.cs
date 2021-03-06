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
            Pedidoes = new HashSet<Pedido>();
        }

        public int Id { get; set; }

        public int UsuarioId { get; set; }

        [Required]
        [StringLength(100)]
        public string Logradouro { get; set; }

        public int Numero { get; set; }

        [StringLength(50)]
        public string Complemento { get; set; }

        [Required]
        [StringLength(8)]
        public string CEP { get; set; }

        [Required]
        [StringLength(40)]
        public string Cidade { get; set; }

        [Required]
        [StringLength(2)]
        public string Sigla { get; set; }

        public int? TipoEndereco { get; set; }

        public virtual Usuario Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedido> Pedidoes { get; set; }
    }
}

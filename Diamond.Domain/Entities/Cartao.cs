namespace Diamond.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Cartao")]
    public partial class Cartao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cartao()
        {
            Pedidoes = new HashSet<Pedido>();
        }

        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public int? BandeiraId { get; set; }

        [Required]
        [StringLength(50)]
        public string Numero { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [StringLength(20)]
        public string Vencimento { get; set; }

        [Required]
        [StringLength(20)]
        public string CCR { get; set; }

        public virtual Bandeira Bandeira { get; set; }

        public virtual Usuario Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedido> Pedidoes { get; set; }
    }
}

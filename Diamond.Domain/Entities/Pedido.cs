namespace Diamond.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Pedido")]
    public partial class Pedido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pedido()
        {
            Pedido_Itens = new HashSet<Pedido_Itens>();
        }

        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public int CartaoId { get; set; }

        public int EnderecoId { get; set; }

        public DateTime DataPedido { get; set; }

        public double ValorTotal { get; set; }

        public virtual Cartao Cartao { get; set; }

        public virtual Endereco Endereco { get; set; }

        public virtual Usuario Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedido_Itens> Pedido_Itens { get; set; }
    }
}

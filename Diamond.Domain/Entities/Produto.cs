namespace Diamond.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Produto")]
    public partial class Produto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Produto()
        {
            Estoque_Entrada = new HashSet<Estoque_Entrada>();
            Pedido_Item = new HashSet<Pedido_Item>();
            Produto_Avaliacao = new HashSet<Produto_Avaliacao>();
            Sub_Categoria = new HashSet<Sub_Categoria>();
        }

        public int Id { get; set; }

        public int MarcaId { get; set; }

        [StringLength(150)]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public double? Preco { get; set; }

        public int? Quantidade { get; set; }

        public bool? Ativo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Estoque_Entrada> Estoque_Entrada { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedido_Item> Pedido_Item { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Produto_Avaliacao> Produto_Avaliacao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sub_Categoria> Sub_Categoria { get; set; }
    }
}

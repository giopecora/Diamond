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
            Estoque_Saida = new HashSet<Estoque_Saida>();
            Pedido_Item = new HashSet<Pedido_Item>();
        }

        public int Id { get; set; }

        public int? CategoriaId { get; set; }

        public int MarcaId { get; set; }

        [StringLength(150)]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public double? Preco { get; set; }

        public int? Quantidade { get; set; }

        public bool? Ativo { get; set; }

        public virtual Categoria Categoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Estoque_Entrada> Estoque_Entrada { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Estoque_Saida> Estoque_Saida { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedido_Item> Pedido_Item { get; set; }
    }
}

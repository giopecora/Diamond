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
        }

        [Key]
        public int id_Produto { get; set; }

        public int id_Categoria { get; set; }

        [StringLength(120)]
        public string nm_Produto { get; set; }

        [StringLength(120)]
        public string ds_produto { get; set; }

        [StringLength(120)]
        public string ds_imagem { get; set; }

        public double? vl_preco { get; set; }

        public int? nr_Quantidade_Estoque { get; set; }

        public virtual Categoria Categoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Estoque_Entrada> Estoque_Entrada { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedido_Item> Pedido_Item { get; set; }
    }
}

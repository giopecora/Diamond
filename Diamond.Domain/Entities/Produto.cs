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
        public int ID_Produto { get; set; }

        public int ID_Categoria { get; set; }

        [StringLength(120)]
        public string NM_Produto { get; set; }

        [StringLength(120)]
        public string DS_produto { get; set; }

        [StringLength(120)]
        public string DS_imagem { get; set; }

        public double? VL_preco { get; set; }

        public int? NR_Quantidade_Estoque { get; set; }

        public bool? FL_Ativo { get; set; }

        public virtual Categoria Categoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Estoque_Entrada> Estoque_Entrada { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedido_Item> Pedido_Item { get; set; }
    }
}

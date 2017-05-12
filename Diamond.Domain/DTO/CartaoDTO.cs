using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Domain.DTO
{
    public class CartaoDTO
    {
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
    }
}

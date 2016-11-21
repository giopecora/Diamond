using Diamond.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Domain.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }

        [StringLength(120)]
        public string Nome { get; set; }

        [StringLength(50)]
        public string Login { get; set; }

        [StringLength(50)]
        public string Senha { get; set; }

        [StringLength(11)]
        public string CPF { get; set; }

        public bool? Ativo { get; set; }
    }
}

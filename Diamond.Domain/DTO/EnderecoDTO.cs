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
    public class EnderecoDTO
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Logradouro { get; set; }

        public int? Numero { get; set; }

        [StringLength(50)]
        public string Complemento { get; set; }

        [StringLength(8)]
        public string CEP { get; set; }

        [StringLength(40)]
        public string Cidade { get; set; }

        [StringLength(2)]
        public string Sigla { get; set; }

        public int? TipoEndereco { get; set; }
    }
}

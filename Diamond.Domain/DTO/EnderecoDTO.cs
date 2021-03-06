﻿using Diamond.Domain.Entities;
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

        [Required]
        [StringLength(100)]
        public string Logradouro { get; set; }

        public int? Numero { get; set; }

        [Required]
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
        public int UsuarioId { get; set; }
    }
}

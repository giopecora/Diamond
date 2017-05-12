using Diamond.Domain.Entities;
using Diamond.Domain.Enums;
using Newtonsoft.Json;
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
        public UsuarioDTO()
        {
            Usuario_Perfis = new List<UsuarioPerfilDTO>
            {
                new UsuarioPerfilDTO() { PerfilId = (int)PerfilEnum.Cliente, Ativo = true }
            };
        }

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

        [JsonProperty("perfis")]
        public List<UsuarioPerfilDTO> Usuario_Perfis { get; set; }

        public bool IsAdmin
        {
            get
            {
                return Usuario_Perfis.Any(p => p.PerfilId == (int)PerfilEnum.Administrador || p.PerfilId == (int)PerfilEnum.Operador);
            }
        }
    }
}

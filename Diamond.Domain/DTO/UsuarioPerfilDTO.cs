using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Domain.DTO
{
    public class UsuarioPerfilDTO
    {
        public int UsuarioId { get; set; }
        public int PerfilId { get; set; }
        public bool Ativo { get; set; }
    }
}

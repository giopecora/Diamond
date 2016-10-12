using Diamond.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Domain.DTO
{
    public class UsuarioDTO
    {
        public UsuarioDTO()
        {

        }

        public UsuarioDTO(Usuario entity)
        {
            Id = entity.ID_Usuario;
            Nome = entity.NM_Usuario;
            Login = entity.NM_login;
            Senha = entity.DS_senha;
            Ativo = entity.FL_Ativo ?? false;
        }

        public Usuario ToEntity()
        {
            return new Usuario()
            {
                ID_Usuario = Id,
                NM_Usuario = Nome,
                NM_login = Login,
                DS_senha = Senha,
                FL_Ativo = Ativo
            };
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
    }
}

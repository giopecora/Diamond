using AutoMapper;
using Diamond.Domain.DTO;
using Diamond.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Domain.AutoMapper
{
    public class UsuarioPerfilProfile : Profile
    {
        public UsuarioPerfilProfile()
        {
            CreateMap<UsuarioPerfilDTO, Usuario_Perfil>().ReverseMap();
        }
    }
}

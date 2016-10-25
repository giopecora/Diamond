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
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<EnderecoDTO, Endereco>().ReverseMap();
        }
    }
}

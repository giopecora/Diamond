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
    public class PedidoItemProfile : Profile
    {
        public PedidoItemProfile()
        {
            CreateMap<PedidoItemDTO, Pedido_Itens>().ReverseMap();
            CreateMap<List<PedidoItemDTO>, List<Pedido_Itens>>().ReverseMap();
        }
    }
}

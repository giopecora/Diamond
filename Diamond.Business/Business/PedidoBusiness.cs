using AutoMapper;
using Diamond.Domain.DTO;
using Diamond.Domain.DTO.Result;
using Diamond.Domain.Entities;
using Diamond.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Business.Business
{
    public class PedidoBusiness
    {
        private PedidoRepository _repository = new PedidoRepository();

        public Result<List<PedidoDTO>> GetAllFromUser(int userId)
        {
            Result<List<PedidoDTO>> result = new Result<List<PedidoDTO>>();
            List<PedidoDTO> pedidos = _repository.GetAllFromUser(userId).ToDTO<Pedido, PedidoDTO>();

            return result.SetData(pedidos);
        }

        public Result<PedidoDTO> GetById(int id)
        {
            Result<PedidoDTO> result = new Result<PedidoDTO>();
            Pedido entity = _repository.GetById(id);

            if (entity == null)
                return result.SetFailure("Este Pedido nao existe!");

            return result.SetData(Mapper.Map<PedidoDTO>(entity));
        }

        public Result<PedidoDTO> Insert(PedidoDTO pedido)
        {
            Result<PedidoDTO> result = new Result<PedidoDTO>();
            Pedido entity = Mapper.Map<Pedido>(pedido);

            foreach(PedidoItemDTO item in pedido.Itens)
            {
                entity.Pedido_Item.Add(Mapper.Map<Pedido_Item>(item));
            }

            entity = _repository.Insert(entity);

            pedido.Id = entity.Id;

            return result.SetData(pedido);
        }

        public Result<bool> Delete(int id)
        {
            Result<bool> result = new Result<bool>();

            result.Success = _repository.Delete(id);

            if (!result.Success)
                result.SetFailure("Nao foi possivel excluir este pedido");

            return result;
        }
    }
}

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
    public class PedidoItemBusiness
    {
        private PedidoItemRepository _repository = new PedidoItemRepository();

        public Result<List<PedidoItemDTO>> GetAllFromPedido(int pedidoId)
        {
            Result<List<PedidoItemDTO>> result = new Result<List<PedidoItemDTO>>();
            List<PedidoItemDTO> itens = _repository.GetAllFromPedido(pedidoId).ToDTO<Pedido_Item, PedidoItemDTO>();

            return result.SetData(itens);
        }

        public Result<PedidoItemDTO> GetById(int id)
        {
            Result<PedidoItemDTO> result = new Result<PedidoItemDTO>();
            Pedido_Item entity = _repository.GetById(id);

            if (entity == null)
                return result.SetFailure("Este Item de Pedido nao existe!");

            return result.SetData(new PedidoItemDTO(entity));
        }

        public Result<PedidoItemDTO> Insert(PedidoItemDTO item)
        {
            Result<PedidoItemDTO> result = new Result<PedidoItemDTO>();
            Pedido_Item entity = _repository.Insert(item.ToEntity());

            item.Id = entity.ID_Pedido_Item;

            return result.SetData(item);
        }

        public Result<bool> Update(int id, PedidoItemDTO item)
        {
            Result<bool> result = new Result<bool>();

            result = _repository.Update(id, item.ToEntity());

            if (!result.Success)
                result.SetFailure("Nao foi possivel atualizar este Item.");

            return result;
        }

        public Result<bool> Delete(int id)
        {
            Result<bool> result = new Result<bool>();

            result.Success = _repository.Delete(id);

            if (!result.Success)
                result.SetFailure("Nao foi possivel excluir este item");

            return result;
        }
    }
}

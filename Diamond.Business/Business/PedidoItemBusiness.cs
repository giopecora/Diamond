using AutoMapper;
using Diamond.Domain.DTO;
using Diamond.Domain.Entities;
using Diamond.Repository.Repository;
using System;
using System.Collections.Generic;

namespace Diamond.Business.Business
{
    public class PedidoItemBusiness
    {
        private PedidoItemRepository _repository = new PedidoItemRepository();

        public List<PedidoItemDTO> GetAllFromPedido(int pedidoId)
        {
            return _repository.GetAllFromPedido(pedidoId).ToDTO<Pedido_Itens, PedidoItemDTO>();
        }

        public PedidoItemDTO GetById(int id)
        {
            Pedido_Itens entity = _repository.GetById(id);

            if (entity == null)
                throw new Exception("Este Item de Pedido nao existe!");

            return Mapper.Map<PedidoItemDTO>(entity);
        }

        public PedidoItemDTO Insert(PedidoItemDTO item)
        {
            Pedido_Itens entity = _repository.Insert(Mapper.Map<Pedido_Itens>(item));

            item.Id = entity.Id;

            return item;
        }

        public void Update(PedidoItemDTO item)
        {
            bool result = _repository.Update(Mapper.Map<Pedido_Itens>(item));

            if (!result)
                throw new Exception("Nao foi possivel atualizar este Item.");
        }

        public void Delete(int id)
        {
            bool success = _repository.Delete(id);

            if (!success)
                throw new Exception("Nao foi possivel excluir este item");
        }
    }
}

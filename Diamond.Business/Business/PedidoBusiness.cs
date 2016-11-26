using AutoMapper;
using Diamond.Domain.DTO;
using Diamond.Domain.Entities;
using Diamond.Repository.Repository;
using System;
using System.Collections.Generic;

namespace Diamond.Business.Business
{
    public class PedidoBusiness
    {
        private PedidoRepository _repository = new PedidoRepository();

        public List<PedidoDTO> GetAllFromUser(int userId, int page)
        {
            return _repository.GetAllFromUser(userId, page).ToDTO<Pedido, PedidoDTO>(); ;
        }

        public PedidoDTO GetById(int id)
        {
            Pedido entity = _repository.GetById(id);

            if (entity == null)
                throw new Exception("Este Pedido nao existe!");

            return Mapper.Map<PedidoDTO>(entity);
        }

        public PedidoDTO Insert(PedidoDTO pedido)
        {
            Pedido entity = Mapper.Map<Pedido>(pedido);

            foreach(PedidoItemDTO item in pedido.Pedido_Item)
            {
                entity.Pedido_Item.Add(Mapper.Map<Pedido_Item>(item));
            }

            entity = _repository.Insert(entity);

            pedido.Id = entity.Id;

            return pedido;
        }

        public void Delete(int id)
        {
            bool success = _repository.Delete(id);

            if (!success)
                throw new Exception("Nao foi possivel excluir este pedido");
        }
    }
}

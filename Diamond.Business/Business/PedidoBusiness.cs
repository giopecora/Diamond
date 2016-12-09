using AutoMapper;
using Diamond.Domain.DTO;
using Diamond.Domain.Entities;
using Diamond.Repository.Repository;
using System;
using System.Collections.Generic;

namespace Diamond.Business.Business
{
    public class PedidoBusiness : BaseBusiness
    {
        private PedidoRepository _repository;

        public PedidoBusiness()
        {
            _repository = new PedidoRepository();
            _repository.UserId = UserId;
        }

        public List<PedidoDTO> GetAllFromUser(int page)
        {
            return _repository.GetAllFromUser(page).ToDTO<Pedido, PedidoDTO>(); ;
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

            foreach(PedidoItemDTO item in pedido.Pedido_Itens)
            {
                entity.Pedido_Itens.Add(Mapper.Map<Pedido_Itens>(item));
            }

            entity = _repository.Insert(entity);

            pedido.Id = entity.Id;

            return pedido;
        }

        public void Delete(int pedidoId)
        {
            bool success = _repository.Delete(pedidoId);

            if (!success)
                throw new Exception("Nao foi possivel excluir este pedido");
        }
    }
}

using AutoMapper;
using Diamond.Domain.DTO;
using Diamond.Domain.DTO.Pedido;
using Diamond.Domain.Entities;
using Diamond.Repository;
using System;
using System.Collections.Generic;

namespace Diamond.Business
{
    public class PedidoBusiness
    {
        private PedidoRepository _repository;
        private EstoqueSaidaBusiness _estoqueSaidaService = new EstoqueSaidaBusiness();

        public PedidoBusiness()
        {
            _repository = new PedidoRepository();
        }

        public List<PedidoDTO> GetAllFromUser(int userId, int page)
        {
            return _repository.GetAllFromUser(userId, page).ToDTO<Pedido, PedidoDTO>(); ;
        }

        public PedidoDetalheDTO GetDetail(int pedidoId)
        {
            PedidoDetalheDTO detalhe = _repository.GetDetail(pedidoId);

            if (detalhe.NumeroCartao.Length == 16)
                detalhe.NumeroCartao = "XXXXXXXXXXXX" + detalhe.NumeroCartao.Substring(12, 4);

            return detalhe;
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

            pedido = Mapper.Map<PedidoDTO>(_repository.Insert(entity));
            pedido.Pedido_Itens.ForEach(pi => _estoqueSaidaService.Insert(new EstoqueSaidaDTO()
            {
                PedidoItemId = pi.Id,
                ProdutoId = pi.ProdutoId,
                Quantidade = pi.Quantidade,
                ValorUnitario = pi.ValorUnitario,
                ValorTotal = pi.ValorTotal,
            }));

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

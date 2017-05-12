using AutoMapper;
using Diamond.Domain.DTO;
using Diamond.Domain.Entities;
using Diamond.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Business
{
    public class CartaoBusiness
    {
        private CartaoRepository _repository;

        public CartaoBusiness()
        {
            _repository = new CartaoRepository();
        }

        public CartaoDTO GetById(int id)
        {
            Cartao entity = _repository.GetById(id);

            if (entity == null)
                throw new Exception("Nao foi possivel encontrar este cartao");

            return Mapper.Map<CartaoDTO>(entity);
        }

        public List<CartaoDTO> GetAllFromUser(int userId)
        {
            return Mapper.Map<List<CartaoDTO>>(_repository.GetAllFromUser(userId));
        }

        public CartaoDTO Insert(CartaoDTO cartao)
        {
            Cartao entity = _repository.Insert(Mapper.Map<Cartao>(cartao));

            cartao.Id = entity.Id;

            return Mapper.Map<CartaoDTO>(entity);
        }

        public void Update(CartaoDTO cartao)
        {
            bool result = _repository.Update(Mapper.Map<Cartao>(cartao));

            if (!result)
                throw new Exception("Nao foi possivel atualizar este Endereco.");
        }

        public void Delete(int id)
        {
            bool success = _repository.Delete(id);

            if (!success)
                throw new Exception("Nao foi possivel excluir este endereco");
        }
    }
}

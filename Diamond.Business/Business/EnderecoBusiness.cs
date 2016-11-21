using AutoMapper;
using Diamond.Domain.DTO;
using Diamond.Domain.Entities;
using Diamond.Repository.Repository;
using System;

namespace Diamond.Business.Business
{
    public class EnderecoBusiness
    {
        private EnderecoRepository _repository = new EnderecoRepository();

        public EnderecoDTO GetById(int id)
        {
            Endereco entity = _repository.GetById(id);

            if (entity == null)
                throw new Exception("Nao foi possivel encontrar este endereco");

            return Mapper.Map<EnderecoDTO>(entity);
        }

        public EnderecoDTO Insert(EnderecoDTO endereco)
        {
            Endereco entity = _repository.Insert(endereco);

            endereco.Id = entity.Id;

            return Mapper.Map<EnderecoDTO>(entity);
        }

        public void Update(EnderecoDTO endereco)
        {
            bool result = _repository.Update(endereco);

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

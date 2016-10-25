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
    public class EnderecoBusiness
    {
        private EnderecoRepository _repository = new EnderecoRepository();

        public Result<EnderecoDTO> GetById(int id)
        {
            Result<EnderecoDTO> result = new Result<EnderecoDTO>();
            Endereco entity = _repository.GetById(id);

            if (entity == null)
                result.SetFailure("Nao foi possivel encontrar este endereco");

            return result.SetData(Mapper.Map<EnderecoDTO>(entity));
        }

        public Result<EnderecoDTO> Insert(EnderecoDTO endereco)
        {
            Result<EnderecoDTO> result = new Result<EnderecoDTO>();
            Endereco entity = _repository.Insert(endereco);

            endereco = Mapper.Map<EnderecoDTO>(entity);

            return result.SetData(endereco);
        }

        public Result<bool> Update(int id, EnderecoDTO endereco)
        {
            Result<bool> result = new Result<bool>();

            result = _repository.Update(id, endereco);

            if (!result.Success)
                result.SetFailure("Nao foi possivel atualizar este Endereco.");

            return result;
        }

        public Result<bool> Delete(int id)
        {
            Result<bool> result = new Result<bool>();

            result.Success = _repository.Delete(id);

            if (!result.Success)
                result.SetFailure("Nao foi possivel excluir este endereco");

            return result;
        }
    }
}

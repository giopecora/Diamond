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
    public class UsuarioBusiness
    {
        private UsuarioRepository _repository = new UsuarioRepository();

        public Result<List<UsuarioDTO>> GetAll()
        {
            Result<List<UsuarioDTO>> result = new Result<List<UsuarioDTO>>();
            List<UsuarioDTO> usuarios = _repository.GetAll().ToDTO<Usuario, UsuarioDTO>();

            return result.SetData(usuarios);
        }

        public Result<UsuarioDTO> GetById(int id)
        {
            Result<UsuarioDTO> result = new Result<UsuarioDTO>();
            Usuario entity = _repository.GetById(id);

            if (entity == null)
                return result.SetFailure("Este Usuario nao existe!");

            return result.SetData(Mapper.Map<UsuarioDTO>(entity));
        }

        public Result<UsuarioDTO> Insert(UsuarioDTO usuario)
        {
            Result<UsuarioDTO> result = new Result<UsuarioDTO>();
            Usuario entity = _repository.Insert(usuario);

            usuario = Mapper.Map<UsuarioDTO>(entity); ;

            return result.SetData(usuario);
        }

        public Result<bool> Update(int id, UsuarioDTO usuario)
        {
            Result<bool> result = new Result<bool>();

            result = _repository.Update(id, usuario);

            if (!result.Success)
                result.SetFailure("Nao foi possivel atualizar este Usuario.");

            return result;
        }

        public Result<bool> Delete(int id)
        {
            Result<bool> result = new Result<bool>();

            UsuarioDTO usuario = GetById(id).Data;
            usuario.Ativo = false;

            result = Update(id, usuario);

            if (!result.Success)
                result.SetFailure("Nao foi possivel excluir este usuario");

            return result;
        }
    }
}

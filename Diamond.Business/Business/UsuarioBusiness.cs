using AutoMapper;
using Diamond.Domain.DTO;
using Diamond.Domain.Entities;
using Diamond.Repository.Repository;
using System;
using System.Collections.Generic;

namespace Diamond.Business.Business
{
    public class UsuarioBusiness
    {
        private UsuarioRepository _repository = new UsuarioRepository();

        public List<UsuarioDTO> GetAll()
        {
            return _repository.GetAll().ToDTO<Usuario, UsuarioDTO>();
        }

        public UsuarioDTO GetById(int id)
        {
            Usuario entity = _repository.GetById(id);

            if (entity == null)
                throw new Exception("Este Usuario nao existe!");

            return Mapper.Map<UsuarioDTO>(entity);
        }

        public UsuarioDTO Insert(UsuarioDTO usuario)
        {
            Usuario entity = _repository.Insert(Mapper.Map<Usuario>(usuario));
            usuario.Id = entity.Id;



            return usuario;
        }

        public void Update(UsuarioDTO usuario)
        {
            bool result = _repository.Update(Mapper.Map<Usuario>(usuario));

            if (!result)
                throw new Exception("Nao foi possivel atualizar este Usuario.");
        }

        public void Delete(int id)
        {
            UsuarioDTO usuario = GetById(id);
            usuario.Ativo = false;

            Update(usuario);
        }
    }
}

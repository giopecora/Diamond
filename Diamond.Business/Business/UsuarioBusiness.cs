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
            Usuario entity = _repository.Insert(usuario);

            usuario.Id = entity.Id;

            return usuario;
        }

        public void Update(int id, UsuarioDTO usuario)
        {
            bool result = _repository.Update(id, usuario);

            if (!result)
                throw new Exception("Nao foi possivel atualizar este Usuario.");
        }

        public void Delete(int id)
        {
            UsuarioDTO usuario = GetById(id);
            usuario.Ativo = false;

            Update(id, usuario);
        }
    }
}

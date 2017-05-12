using AutoMapper;
using Diamond.Domain.DTO;
using Diamond.Domain.Entities;
using Diamond.Repository;
using System;

namespace Diamond.Business
{
    public class AuthenticationBusiness
    {
        private AuthenticationRepository _repository = new AuthenticationRepository();

        public UsuarioDTO FindUser(string username, string password)
        {
            UsuarioDTO usuario;

            try
            {
                Usuario entity = _repository.FindUser(username, password);

                usuario = Mapper.Map<UsuarioDTO>(entity);
            }
            catch(Exception ex)
            {
                return null;
            }

            return usuario;
        }
    }
}

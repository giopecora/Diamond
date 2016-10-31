using AutoMapper;
using Diamond.Domain.DTO;
using Diamond.Domain.Entities;
using Diamond.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Business.Business
{
    public class AuthenticationBusiness
    {
        private AuthenticationRepository _repository = new AuthenticationRepository();

        public UsuarioDTO FindUser(string username, string password)
        {
            Usuario user = _repository.FindUser(username, password);

            return Mapper.Map<UsuarioDTO>(user);
        }
    }
}

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
    public class AuthenticationBusiness
    {
        private AuthenticationRepository _repository = new AuthenticationRepository();

        public Result<UsuarioDTO> FindUser(string username, string password)
        {
            Result<UsuarioDTO> result = new Result<UsuarioDTO>();

            try
            {
                Usuario user = _repository.FindUser(username, password);

                return result.SetData(Mapper.Map<UsuarioDTO>(user));
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }

            return result;
        }
    }
}

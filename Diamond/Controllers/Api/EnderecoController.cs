using Diamond.Business.Business;
using Diamond.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Diamond.Controllers.Api
{
    [Authorize]
    public class EnderecoController : BaseApiController
    {
        private EnderecoBusiness _business = new EnderecoBusiness();

        [ResponseType(typeof(EnderecoDTO))]
        public IHttpActionResult Get(int id)
        {
            EnderecoDTO endereco = new EnderecoDTO();

            try
            {
                endereco = _business.GetById(id);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(endereco);
        }

        [Route("api/Endereco/GetAllFromUser/{userId:int}")]
        [ResponseType(typeof(List<EnderecoDTO>))]
        public IHttpActionResult GetAllFromUser(int userId)
        {
            List<EnderecoDTO> enderecos = new List<EnderecoDTO>();

            try
            {
                enderecos = _business.GetAllFromUser(userId);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(enderecos);
        }

        [ResponseType(typeof(IHttpActionResult))]
        public IHttpActionResult Put([FromBody]EnderecoDTO endereco)
        {
            try
            {
                _business.Update(endereco);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok();
        }

        // POST: api/Produtos
        [ResponseType(typeof(EnderecoDTO))]
        public IHttpActionResult Post(int userId, [FromBody]EnderecoDTO endereco)
        {
            EnderecoDTO result = new EnderecoDTO();

            try
            {
                result = _business.Insert(userId, endereco);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(result);
        }

        // DELETE: api/Produtos/5
        [ResponseType(typeof(IHttpActionResult))]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _business.Delete(id);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok();
        }
    }
}

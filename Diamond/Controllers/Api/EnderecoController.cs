using Diamond.Business.Business;
using Diamond.Domain.DTO;
using System;
using System.Web.Http;
using System.Web.Http.Description;

namespace Diamond.Controllers.Api
{
    public class EnderecoController : ApiController
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
        public IHttpActionResult Post([FromBody]EnderecoDTO endereco)
        {
            EnderecoDTO result = new EnderecoDTO();

            try
            {
                result = _business.Insert(endereco);
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

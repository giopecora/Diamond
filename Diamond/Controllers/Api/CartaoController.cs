using Diamond.Business.Business;
using Diamond.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace Diamond.Controllers.Api
{
    public class CartaoController : BaseApiController
    {
        private CartaoBusiness _business;

        public CartaoController()
        {
            _business = new CartaoBusiness();

            if (UserId.HasValue)
                _business.UserId = UserId.Value;
        }

        [ResponseType(typeof(CartaoDTO))]
        public IHttpActionResult Get(int id)
        {
            CartaoDTO cartao = new CartaoDTO();

            if (!UserId.HasValue)
                return Unauthorized();

            try
            {
                cartao = _business.GetById(id);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(cartao);
        }

        [Route("api/Cartao/GetAllFromUser")]
        [ResponseType(typeof(List<CartaoDTO>))]
        public IHttpActionResult GetAllFromUser()
        {
            List<CartaoDTO> cartoes = new List<CartaoDTO>();

            if (!UserId.HasValue)
                return Unauthorized();

            try
            {
                cartoes = _business.GetAllFromUser();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(cartoes);
        }

        [ResponseType(typeof(IHttpActionResult))]
        public IHttpActionResult Put([FromBody]CartaoDTO cartao)
        {
            if (!UserId.HasValue)
                return Unauthorized();

            cartao.UsuarioId = UserId.Value;

            try
            {
                _business.Update(cartao);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok();
        }

        // POST: api/Produtos
        [ResponseType(typeof(EnderecoDTO))]
        public IHttpActionResult Post([FromBody]CartaoDTO cartao)
        {
            if (!UserId.HasValue)
                return Unauthorized();

            cartao.UsuarioId = UserId.Value;

            try
            {
                cartao = _business.Insert(cartao);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(cartao);
        }

        // DELETE: api/Produtos/5
        [ResponseType(typeof(IHttpActionResult))]
        public IHttpActionResult Delete(int id)
        {
            if (!UserId.HasValue)
                return Unauthorized();

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
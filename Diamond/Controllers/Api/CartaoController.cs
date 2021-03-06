﻿using Diamond.Business;
using Diamond.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace Diamond.Controllers.Api
{
    [Authorize]
    public class CartaoController : BaseApiController
    {
        private CartaoBusiness _business = new CartaoBusiness();

        [ResponseType(typeof(CartaoDTO))]
        public IHttpActionResult Get(int id)
        {
            CartaoDTO cartao = new CartaoDTO();

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

            try
            {
                int userId = Convert.ToInt32(OwinContextProvider.GetClaimValue("userId"));
                cartoes = _business.GetAllFromUser(userId);
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
        [ResponseType(typeof(CartaoDTO))]
        public IHttpActionResult Post([FromBody]CartaoDTO cartao)
        {
            try
            {
                cartao.UsuarioId = Convert.ToInt32(OwinContextProvider.GetClaimValue("userId"));
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
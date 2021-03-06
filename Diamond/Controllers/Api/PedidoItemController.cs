﻿using Diamond.Business;
using Diamond.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Diamond.Controllers.Api
{
    [Authorize]
    public class PedidoItemController : BaseApiController
    {
        private PedidoItemBusiness _business = new PedidoItemBusiness();

        [ResponseType(typeof(List<PedidoItemDTO>))]
        [Route("api/PedidoItem/GetAllFromPedido/{pedidoId:int}")]
        // GET: api/Produtos
        public IHttpActionResult GetAllFromPedido(int pedidoId)
        {
            List<PedidoItemDTO> itens = new List<PedidoItemDTO>();

            try
            {
                itens = _business.GetAllFromPedido(pedidoId);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(itens);
        }

        [ResponseType(typeof(PedidoItemDTO))]
        public IHttpActionResult Get(int id)
        {
            PedidoItemDTO item = new PedidoItemDTO();

            try
            {
                item = _business.GetById(id);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(item);
        }

        // PUT: api/Produtos/5
        [ResponseType(typeof(IHttpActionResult))]
        public IHttpActionResult Put([FromBody]PedidoItemDTO pedidoItem)
        {
            try
            {
                _business.Update(pedidoItem);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok();
        }

        // POST: api/Produtos
        [ResponseType(typeof(PedidoItemDTO))]
        public IHttpActionResult Post([FromBody]PedidoItemDTO pedidoItem)
        {        
            try
            {
                pedidoItem = _business.Insert(pedidoItem);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(pedidoItem);
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

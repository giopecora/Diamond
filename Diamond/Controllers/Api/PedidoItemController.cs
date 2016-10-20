using Diamond.Business.Business;
using Diamond.Domain.DTO;
using Diamond.Domain.DTO.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Diamond.Controllers.Api
{
    public class PedidoItemController : ApiController
    {
        private PedidoItemBusiness _business = new PedidoItemBusiness();

        [ResponseType(typeof(Result<List<PedidoItemDTO>>))]
        [Route("api/PedidoItem/GetAllFromPedido/{pedidoId:int}")]
        // GET: api/Produtos
        public IHttpActionResult GetAllFromPedido(int pedidoId)
        {
            Result<List<PedidoItemDTO>> result = new Result<List<PedidoItemDTO>>();

            try
            {
                result = _business.GetAllFromPedido(pedidoId);
            }
            catch (Exception ex)
            {
                result.SetError(ex);
            }

            return Ok(result);
        }

        [ResponseType(typeof(Result<PedidoItemDTO>))]
        public IHttpActionResult Get(int id)
        {
            Result<PedidoItemDTO> result = new Result<PedidoItemDTO>();

            try
            {
                result = _business.GetById(id);
            }
            catch (Exception ex)
            {
                result.SetError(ex);
            }

            return Ok(result);
        }

        // PUT: api/Produtos/5
        [ResponseType(typeof(Result<bool>))]
        public IHttpActionResult Put(int id, [FromBody]PedidoItemDTO pedidoItem)
        {
            Result<bool> result = new Result<bool>();

            try
            {
                result = _business.Update(id, pedidoItem);
            }
            catch (Exception ex)
            {
                result.SetError(ex);
            }

            return Ok(result);
        }

        // POST: api/Produtos
        [ResponseType(typeof(Result<PedidoItemDTO>))]
        public IHttpActionResult Post([FromBody]PedidoItemDTO pedidoItem)
        {
            Result<PedidoItemDTO> result = new Result<PedidoItemDTO>();

            try
            {
                result = _business.Insert(pedidoItem);
            }
            catch (Exception ex)
            {
                result.SetError(ex);
            }

            return Ok(result);
        }

        // DELETE: api/Produtos/5
        [ResponseType(typeof(Result<bool>))]
        public IHttpActionResult Delete(int id)
        {
            Result<bool> result = new Result<bool>();

            try
            {
                result = _business.Delete(id);
            }
            catch (Exception ex)
            {
                result.SetError(ex);
            }

            return Ok(result);
        }
    }
}

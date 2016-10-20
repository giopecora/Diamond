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
    public class PedidoController : ApiController
    {
        private PedidoBusiness _business = new PedidoBusiness();

        [ResponseType(typeof(Result<List<PedidoDTO>>))]
        [Route("api/Pedido/GetAllFromUser/{userId:int}")]
        // GET: api/Produtos
        public IHttpActionResult GetAllFromUser(int userId)
        {
            Result<List<PedidoDTO>> result = new Result<List<PedidoDTO>>();

            try
            {
                result = _business.GetAllFromUser(userId);
            }
            catch (Exception ex)
            {
                result.SetError(ex);
            }

            return Ok(result);
        }

        [ResponseType(typeof(Result<PedidoDTO>))]
        // GET: api/Produtos
        public IHttpActionResult GetById(int id)
        {
            Result<PedidoDTO> result = new Result<PedidoDTO>();

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

        // POST: api/Produtos
        [ResponseType(typeof(Result<PedidoDTO>))]
        public IHttpActionResult Post([FromBody]PedidoDTO pedido)
        {
            Result<PedidoDTO> result = new Result<PedidoDTO>();

            try
            {
                result = _business.Insert(pedido);
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

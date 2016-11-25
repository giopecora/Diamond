using Diamond.Business.Business;
using Diamond.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Diamond.Controllers.Api
{
    public class PedidoController : ApiController
    {
        private PedidoBusiness _business = new PedidoBusiness();

        [ResponseType(typeof(List<PedidoDTO>))]
        [Route("api/Pedido/GetAllFromUser/{userId:int}/{page:int}")]
        // GET: api/Produtos
        public IHttpActionResult GetAllFromUser(int userId, int page)
        {
            List<PedidoDTO> pedidos = new List<PedidoDTO>();

            try
            {
                pedidos = _business.GetAllFromUser(userId, page);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(pedidos);
        }

        [ResponseType(typeof(PedidoDTO))]
        // GET: api/Produtos
        public IHttpActionResult GetById(int id)
        {
            PedidoDTO pedido = new PedidoDTO();

            try
            {
                pedido = _business.GetById(id);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(pedido);
        }

        // POST: api/Produtos
        [ResponseType(typeof(PedidoDTO))]
        public IHttpActionResult Post([FromBody]PedidoDTO pedido)
        {
            try
            {
                pedido = _business.Insert(pedido);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(pedido);
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

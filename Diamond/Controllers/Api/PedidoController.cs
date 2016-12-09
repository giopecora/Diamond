using Diamond.Business.Business;
using Diamond.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Diamond.Controllers.Api
{
    [Authorize]
    public class PedidoController : BaseApiController
    {
        private PedidoBusiness _business = new PedidoBusiness();

        public PedidoController()
        {
            _business = new PedidoBusiness();

            if (UserId.HasValue)
                _business.UserId = UserId.Value;
        }

        [ResponseType(typeof(List<PedidoDTO>))]
        [Route("api/Pedido/GetAllFromUser/{page:int}")]
        // GET: api/Produtos
        public IHttpActionResult GetAllFromUser(int page)
        {
            List<PedidoDTO> pedidos = new List<PedidoDTO>();

            if (!UserId.HasValue)
                return Unauthorized();

            try
            {
                pedidos = _business.GetAllFromUser(page);
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

            if (!UserId.HasValue)
                return Unauthorized();

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
            if (!UserId.HasValue)
                return Unauthorized();

            pedido.UsuarioId = UserId.Value;

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

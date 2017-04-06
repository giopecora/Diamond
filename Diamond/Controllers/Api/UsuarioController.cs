using Diamond.Business.Business;
using Diamond.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Diamond.Controllers.Api
{
    public class UsuarioController : BaseApiController
    {
        private UsuarioBusiness _business = new UsuarioBusiness();

        [Authorize]
        [ResponseType(typeof(List<UsuarioDTO>))]
        public IHttpActionResult GetAll()
        {
            List<UsuarioDTO> usuarios = new List<UsuarioDTO>();

            try
            {
                usuarios = _business.GetAll();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(usuarios);
        }

        [Authorize]
        [ResponseType(typeof(UsuarioDTO))]
        [Route("api/Usuario/Get/{userId:int}")]
        public IHttpActionResult Get(int userId)
        {
            UsuarioDTO usuario = new UsuarioDTO();

            try
            {
                if (AuthenticatedUserId.HasValue)
                {
                    usuario = _business.GetById(AuthenticatedUserId.Value);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(usuario);
        }

        [Authorize]
        [ResponseType(typeof(IHttpActionResult))]
        public IHttpActionResult Put([FromBody]UsuarioDTO usuario)
        {
            try
            {
                _business.Update(usuario);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok();
        }

        // POST: api/Produtos
        [ResponseType(typeof(UsuarioDTO))]
        public IHttpActionResult Post([FromBody]UsuarioDTO usuario)
        {
            try
            {
                usuario = _business.Insert(usuario);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(usuario);
        }

        [Authorize]
        [ResponseType(typeof(IHttpActionResult))]
        public IHttpActionResult Delete(int userId)
        {
            try
            {
                _business.Delete(userId);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok();
        }
    }
}

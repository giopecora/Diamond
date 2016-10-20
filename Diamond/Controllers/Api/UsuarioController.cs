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
    public class UsuarioController : ApiController
    {
        private UsuarioBusiness _business = new UsuarioBusiness();

        [ResponseType(typeof(Result<List<UsuarioDTO>>))]
        // GET: api/Produtos
        public IHttpActionResult GetAll()
        {
            Result<List<UsuarioDTO>> result = new Result<List<UsuarioDTO>>();

            try
            {
                result = _business.GetAll();
            }
            catch (Exception ex)
            {
                result.SetError(ex);
            }

            return Ok(result);
        }

        [ResponseType(typeof(Result<UsuarioDTO>))]
        public IHttpActionResult Get(int id)
        {
            Result<UsuarioDTO> result = new Result<UsuarioDTO>();

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
        public IHttpActionResult Put(int id, [FromBody]UsuarioDTO usuario)
        {
            Result<bool> result = new Result<bool>();

            try
            {
                result = _business.Update(id, usuario);
            }
            catch (Exception ex)
            {
                result.SetError(ex);
            }

            return Ok(result);
        }

        // POST: api/Produtos
        [ResponseType(typeof(Result<UsuarioDTO>))]
        public IHttpActionResult Post([FromBody]UsuarioDTO usuario)
        {
            Result<UsuarioDTO> result = new Result<UsuarioDTO>();

            try
            {
                result = _business.Insert(usuario);
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

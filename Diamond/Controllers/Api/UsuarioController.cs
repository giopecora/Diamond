﻿using Diamond.Business.Business;
using Diamond.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Diamond.Controllers.Api
{
    [Authorize]
    public class UsuarioController : ApiController
    {
        private UsuarioBusiness _business = new UsuarioBusiness();

        [ResponseType(typeof(List<UsuarioDTO>))]
        // GET: api/Produtos
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

        [ResponseType(typeof(UsuarioDTO))]
        public IHttpActionResult Get(int id)
        {
            UsuarioDTO usuario = new UsuarioDTO();

            try
            {
                usuario = _business.GetById(id);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(usuario);
        }

        // PUT: api/Produtos/5
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

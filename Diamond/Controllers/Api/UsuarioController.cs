﻿using Diamond.Business.Business;
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
        public IHttpActionResult Get()
        {
            UsuarioDTO usuario = new UsuarioDTO();

            if (!UserId.HasValue)
                return Unauthorized();

            try
            {
                usuario = _business.GetById(UserId.Value);
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
            if (!UserId.HasValue)
                return Unauthorized();

            usuario.Id = UserId.Value;

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
            if (!UserId.HasValue)
                return Unauthorized();

            usuario.Id = UserId.Value;

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
        public IHttpActionResult Delete()
        {
            if (!UserId.HasValue)
                return Unauthorized();

            try
            {
                _business.Delete(UserId.Value);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok();
        }
    }
}

﻿using Diamond.Business.Business;
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
    public class EnderecoController : ApiController
    {
        private EnderecoBusiness _business = new EnderecoBusiness();

        [ResponseType(typeof(Result<EnderecoDTO>))]
        public IHttpActionResult Get(int id)
        {
            EnderecoDTO endereco = new EnderecoDTO();

            try
            {
                endereco = _business.GetById(id);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(endereco);
        }

        [ResponseType(typeof(Result<bool>))]
        public IHttpActionResult Put(int id, [FromBody]EnderecoDTO endereco)
        {
            Result<bool> result = new Result<bool>();

            try
            {
                _business.Update(id, endereco);
            }
            catch (Exception ex)
            {
                result.SetError(ex);
            }

            return Ok(result);
        }

        // POST: api/Produtos
        [ResponseType(typeof(Result<EnderecoDTO>))]
        public IHttpActionResult Post([FromBody]EnderecoDTO endereco)
        {
            EnderecoDTO result = new EnderecoDTO();

            try
            {
                result = _business.Insert(endereco);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
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
                _business.Delete(id);
            }
            catch (Exception ex)
            {
                result.SetError(ex);
            }

            return Ok(result);
        }
    }
}

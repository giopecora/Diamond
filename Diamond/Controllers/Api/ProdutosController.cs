using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Diamond.Domain.Entities;
using Diamond.Models;
using Diamond.Business;
using Diamond.Domain.DTO;
using Diamond.Domain.DTO.Result;

namespace Diamond.Controllers.Api
{
    public class ProdutosController : ApiController
    {
        private ProdutoBusiness _business = new ProdutoBusiness();

        // GET: api/Produtos
        public IHttpActionResult GetAll()
        {
            Result<List<ProdutoDTO>> result = new Result<List<ProdutoDTO>>();

            try
            {
                result = _business.GetAll();
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }

            return Ok(result);
        }

        // GET: api/Produtos/5
        [ResponseType(typeof(Produto))]
        public IHttpActionResult GetProduto(int id)
        {
            Result<List<ProdutoDTO>> result = new Result<List<ProdutoDTO>>();

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

        // PUT: api/Produtos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduto(int id, Produto produto)
        {
            Result<List<ProdutoDTO>> result = new Result<List<ProdutoDTO>>();

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

        // POST: api/Produtos
        [ResponseType(typeof(Produto))]
        public IHttpActionResult PostProduto(Produto produto)
        {
            Result<List<ProdutoDTO>> result = new Result<List<ProdutoDTO>>();

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

        // DELETE: api/Produtos/5
        [ResponseType(typeof(Produto))]
        public IHttpActionResult DeleteProduto(int id)
        {
            Result<List<ProdutoDTO>> result = new Result<List<ProdutoDTO>>();

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
    }
}
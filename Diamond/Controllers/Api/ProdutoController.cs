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
    public class ProdutoController : ApiController
    {
        private ProdutoBusiness _business = new ProdutoBusiness();

        [ResponseType(typeof(Result<List<ProdutoDestaqueDTO>>))]
        [Route("api/Produto/GetTop5")]
        public IHttpActionResult GetTop5()
        {
            Result<List<ProdutoDestaqueDTO>> result = new Result<List<ProdutoDestaqueDTO>>();

            try
            {
                result = _business.GetTop5();
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }

            return Ok(result);
        }

        [ResponseType(typeof(Result<List<ProdutoDestaqueDTO>>))]
        [Route("api/Produto/GetTop4OfAllCategories")]
        public IHttpActionResult GetTop4OfAllCategories()
        {
            Result<List<ProdutoDestaqueDTO>> result = new Result<List<ProdutoDestaqueDTO>>();

            try
            {
                result = _business.GetTop4OfAllCategories();
            }
            catch (Exception ex)
            {
                result.SetError(ex);
            }

            return Ok(result);
        }

        [ResponseType(typeof(Result<List<ProdutoDTO>>))]
        [Route("api/Produto/GetTop3CheaperByCategory/{categoryId:int}")]
        public IHttpActionResult GetTop3CheaperByCategory(int categoryId)
        {
            Result<List<ProdutoDTO>> result = new Result<List<ProdutoDTO>>();

            try
            {
                result = _business.GetTop3CheaperByCategory(categoryId);
            }
            catch (Exception ex)
            {
                result.SetError(ex);
            }

            return Ok(result);
        }

        [ResponseType(typeof(Result<List<ProdutoDTO>>))]
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

        [ResponseType(typeof(Result<List<ProdutoDTO>>))]
        [Route("api/Produto/GetAllFromCategory/{categoryId:int}")]
        public IHttpActionResult GetAllFromCategory(int categoryId)
        {
            Result<List<ProdutoDTO>> result = new Result<List<ProdutoDTO>>();

            try
            {
                result = _business.GetAllByCategoryId(categoryId);
            }
            catch (Exception ex)
            {
                result.SetError(ex);
            }

            return Ok(result);
        }

        // GET: api/Produtos/5
        [ResponseType(typeof(Result<ProdutoDTO>))]
        public IHttpActionResult Get(int id)
        {
            Result<ProdutoDTO> result = new Result<ProdutoDTO>();

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
        public IHttpActionResult Put(int id, [FromBody]ProdutoDTO produto)
        {
            Result<bool> result = new Result<bool>();

            try
            {
                result = _business.Update(id, produto);
            }
            catch (Exception ex)
            {
                result.SetError(ex);
            }

            return Ok(result);
        }

        // POST: api/Produtos
        [ResponseType(typeof(Result<ProdutoDTO>))]
        public IHttpActionResult Post([FromBody]ProdutoDTO produto)
        {
            Result<ProdutoDTO> result = new Result<ProdutoDTO>();

            try
            {
                result = _business.Insert(produto);
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
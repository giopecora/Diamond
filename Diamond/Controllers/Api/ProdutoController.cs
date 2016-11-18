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

        [ResponseType(typeof(List<ProdutoDestaqueDTO>))]
        [Route("api/Produto/GetTop5")]
        public IHttpActionResult GetTop5()
        {
            List<ProdutoDestaqueDTO> destaques = new List<ProdutoDestaqueDTO>();

            try
            {
                destaques = _business.GetTop5();
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(destaques);
        }

        [ResponseType(typeof(List<ProdutoDestaqueDTO>))]
        [Route("api/Produto/GetTop4OfAllCategories")]
        public IHttpActionResult GetTop4OfAllCategories()
        {
            List<ProdutoDestaqueDTO> destaques = new List<ProdutoDestaqueDTO>();

            try
            {
                destaques = _business.GetTop4OfAllCategories();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(destaques);
        }

        [ResponseType(typeof(List<ProdutoDTO>))]
        [Route("api/Produto/GetTop3CheaperByCategory/{categoryId:int}")]
        public IHttpActionResult GetTop3CheaperByCategory(int categoryId)
        {
            List<ProdutoDTO> produtos = new List<ProdutoDTO>();

            try
            {
                produtos = _business.GetTop3CheaperByCategory(categoryId);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(produtos);
        }

        [ResponseType(typeof(Result<List<ProdutoDTO>>))]
        // GET: api/Produtos
        public IHttpActionResult GetAll()
        {
            List<ProdutoDTO> produtos = new List<ProdutoDTO>();

            try
            {
                produtos = _business.GetAll();
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(produtos);
        }

        [ResponseType(typeof(List<ProdutoDTO>))]
        [Route("api/Produto/GetAllFromCategory/{categoryId:int}")]
        public IHttpActionResult GetAllFromCategory(int categoryId)
        {
            List<ProdutoDTO> produtos = new List<ProdutoDTO>();

            try
            {
                produtos = _business.GetAllByCategoryId(categoryId);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(produtos);
        }

        // GET: api/Produtos/5
        [ResponseType(typeof(ProdutoDTO))]
        public IHttpActionResult Get(int id)
        {
            ProdutoDTO produto = new ProdutoDTO();

            try
            {
                produto = _business.GetById(id);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(produto);
        }

        // PUT: api/Produtos/5
        [ResponseType(typeof(IHttpActionResult))]
        public IHttpActionResult Put(int id, [FromBody]ProdutoDTO produto)
        {
            try
            {
                _business.Update(id, produto);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok();
        }

        // POST: api/Produtos
        [ResponseType(typeof(ProdutoDTO))]
        public IHttpActionResult Post([FromBody]ProdutoDTO produto)
        {
            try
            {
                produto = _business.Insert(produto);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(produto);
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
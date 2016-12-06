using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using Diamond.Business;
using Diamond.Domain.DTO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Diamond.Business.Business;
using Diamond.Domain.Models.Produto;

namespace Diamond.Controllers.Api
{
    public class ProdutoController : ApiController
    {
        private ProdutoBusiness _business = new ProdutoBusiness();
        private ProdutoImagemBusiness _imagemBusiness = new ProdutoImagemBusiness();

        [ResponseType(typeof(List<ProdutoDTO>))]
        [Route("api/Produto/SearchForProducts/{search}")]
        public IHttpActionResult SearchForProducts(string search)
        {
            List<ProdutoDTO> produtos = new List<ProdutoDTO>();

            try
            {
                produtos = _business.SearchForProducts(search);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(produtos);
        }

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

        [Authorize]
        [ResponseType(typeof(List<ProdutoDTO>))]
        public IHttpActionResult GetAll([FromUri]Filtro filtro, int page)
        {
            List<ProdutoDTO> produtos = new List<ProdutoDTO>();

            try
            {
                produtos = _business.GetAll(filtro, page);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(produtos);
        }

        [ResponseType(typeof(List<ProdutoDTO>))]
        [Route("api/Produto/GetAllFromCategory/{categoryId:int}/{page:int}")]
        public IHttpActionResult GetAllFromCategory(int categoryId, int page = 1)
        {
            List<ProdutoDTO> produtos = new List<ProdutoDTO>();

            try
            {
                produtos = _business.GetAllByCategoryId(categoryId, page);
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
        [Authorize]
        [ResponseType(typeof(IHttpActionResult))]
        public IHttpActionResult Put([FromBody]ProdutoDTO produto)
        {
            try
            {
                _business.Update(produto);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok();
        }

        // POST: api/Produtos
        [Authorize]
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

        [Authorize]
        [HttpPost]
        public IHttpActionResult Upload(int produtoId)
        {
            try
            {
                _imagemBusiness.Upload(produtoId, HttpContext.Current);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok();
        }

        // DELETE: api/Produtos/5
        [Authorize]
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
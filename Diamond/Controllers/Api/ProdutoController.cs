using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using Diamond.Business;
using Diamond.Domain.DTO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Diamond.Domain.Models.Produto;
using Diamond.Filters;
using Diamond.Providers;
using System.IO;
using Diamond.Utils.Helpers;

namespace Diamond.Controllers.Api
{
    public class ProdutoController : BaseApiController
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
            catch (Exception ex)
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

        [Authorize]
        [ClaimsAuthorize("isAdmin", "1")]
        [ResponseType(typeof(List<ProdutoDTO>))]
        public IHttpActionResult GetAll([FromUri]Filtro filtro, int page)
        {
            List<ProdutoDTO> produtos = new List<ProdutoDTO>();

            try
            {
                produtos = _business.GetAll(filtro, page);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(produtos);
        }

        [HttpGet]
        [ClaimsAuthorize("isAdmin", "1")]
        [ResponseType(typeof(List<ProdutoDTO>))]
        [Route("api/Produto/ListAll/{page}")]
        public IHttpActionResult ListAll(int page)
        {
            List<ProdutoDTO> produtos = new List<ProdutoDTO>();

            try
            {
                produtos = _business.ListAll(page);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(produtos);
        }

        [HttpGet]
        [ClaimsAuthorize("isAdmin", "1")]
        [ResponseType(typeof(List<ProdutoDTO>))]
        [Route("api/Produto/ListAllByName/{page}/{name}")]
        public IHttpActionResult ListAllByName(int page, string name)
        {
            List<ProdutoDTO> produtos = new List<ProdutoDTO>();

            try
            {
                produtos = _business.ListAllByName(page, name);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(produtos);
        }

        [HttpGet]
        public IHttpActionResult GetCount()
        {
            return Ok(_business.GetCount());
        }

        [HttpGet]
        [ClaimsAuthorize("isAdmin", "1")]
        [Route("api/Produto/GetCountByName/{name}")]
        public IHttpActionResult GetCountByName(string name)
        {
            return Ok(_business.GetCountByName(name));
        }

        [ResponseType(typeof(List<ProdutoDTO>))]
        [Route("api/Produto/GetAllFromCategory/{categoryId:int}/{page:int}")]
        public IHttpActionResult GetAllFromCategory(int categoryId, int page = 0)
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
        [ClaimsAuthorize("isAdmin", "1")]
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
        [ClaimsAuthorize("isAdmin", "1")]
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
        [ClaimsAuthorize("isAdmin", "1")]
        [HttpPost]
        public async Task<IHttpActionResult> Upload(int produtoId)
        {
            string uploadPath = "";

            try
            {
                List<ProdutoImagemDTO> imagens = new List<ProdutoImagemDTO>();
                var provider = new CustomMultipartFormDataStreamProvider(DirectoryHelper.GetDirectory($@"C:\Produtos\Produto_{produtoId}\"));

                await Task.Run(async () => await Request.Content.ReadAsMultipartAsync(provider));

                foreach(var file in provider.FileData)
                {
                    var fileInfo = new FileInfo(file.LocalFileName);
                    var filePath = $@"Produto_{produtoId}\{fileInfo.Name}";

                    uploadPath = $@"C:\Produtos\{filePath}";

                    imagens.Add(new ProdutoImagemDTO()
                    {
                        ProdutoId = produtoId,
                        Imagem = uploadPath
                    });

                    _business.UploadImagemPrincipal(produtoId, filePath);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(uploadPath);
        }

        // DELETE: api/Produtos/5
        [Authorize]
        [ClaimsAuthorize("isAdmin", "1")]
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
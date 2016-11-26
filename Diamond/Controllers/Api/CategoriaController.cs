using Diamond.Business.Business;
using Diamond.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Diamond.Controllers.Api
{
    public class CategoriaController : ApiController
    {
        private CategoriaBusiness _business = new CategoriaBusiness();

        [ResponseType(typeof(List<CategoriaDTO>))]
        [HttpGet]
        public IHttpActionResult ListTop8ProductsOfAllCategories()
        {
            List<CategoriaDTO> categorias = new List<CategoriaDTO>();

            try
            {
                categorias = _business.ListTop8ProductsOfAllCategories();
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(categorias);
        }
    }
}

using Diamond.Business.Business;
using Diamond.Domain.DTO;
using Diamond.Domain.Models;
using Diamond.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Diamond.Controllers.Api
{
    [Authorize]
    [ClaimsAuthorize("isAdmin", "1")]
    public class ReportController : BaseApiController
    {
        private ReportBusiness _business = new ReportBusiness();

        [HttpGet]
        [ResponseType(typeof(RelatorioDTO))]
        public IHttpActionResult ProductSellsAnalytics([FromUri]Filtro filtro, int page)
        {
            List<RelatorioDTO> relatorio = new List<RelatorioDTO>();

            try
            {
                relatorio = _business.ListSellsProductReportAnalytics(filtro, page);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(relatorio);
        }

        [HttpGet]
        [ResponseType(typeof(RelatorioDTO))]
        public IHttpActionResult ProductSellsSintetics([FromUri]Filtro filtro, int page)
        {
            List<RelatorioDTO> relatorio = new List<RelatorioDTO>();

            try
            {
                relatorio = _business.ListSellsProductReportSintetics(filtro, page);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(relatorio);
        }

        [HttpGet]
        [ResponseType(typeof(RelatorioDTO))]
        public IHttpActionResult ProductBuysAnalytics([FromUri]Filtro filtro, int page)
        {
            List<RelatorioDTO> relatorio = new List<RelatorioDTO>();

            try
            {
                relatorio = _business.ListBuysProductReportAnalytics(filtro, page);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(relatorio);
        }

        [HttpGet]
        [ResponseType(typeof(RelatorioDTO))]
        public IHttpActionResult ProductBuysSintetics([FromUri]Filtro filtro, int page)
        {
            List<RelatorioDTO> relatorio = new List<RelatorioDTO>();

            try
            {
                relatorio = _business.ListBuysProductReportSintetics(filtro, page);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(relatorio);
        }
    }
}

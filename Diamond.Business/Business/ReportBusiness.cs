using Diamond.Domain.DTO;
using Diamond.Domain.Models;
using Diamond.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Business
{
    public class ReportBusiness
    {
        private ReportRepository _repository = new ReportRepository();

        public List<RelatorioDTO> ListSellsProductReportAnalytics(Filtro filtro, int page)
        {
            return _repository.ListSellsProductReportAnalytics(filtro.MontarQuery(), page);
        }

        public List<RelatorioDTO> ListSellsProductReportSintetics(Filtro filtro, int page)
        {
            return _repository.ListSellsProductReportSintetics(filtro.MontarQuery(), page);
        }

        public List<RelatorioDTO> ListBuysProductReportAnalytics(Filtro filtro, int page)
        {
            return _repository.ListBuysProductReportAnalytics(filtro.MontarQuery(), page);
        }

        public List<RelatorioDTO> ListBuysProductReportSintetics(Filtro filtro, int page)
        {
            return _repository.ListBuysProductReportSintetics(filtro.MontarQuery(), page);
        }
    }
}

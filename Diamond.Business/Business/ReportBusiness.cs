using Diamond.Domain.DTO;
using Diamond.Domain.Models;
using Diamond.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Business.Business
{
    public class ReportBusiness
    {
        private ReportRepository _repository = new ReportRepository();

        public List<RelatorioDTO> ListSellsProductReportAnalytics(Filtro filtro)
        {
            return _repository.ListSellsProductReportAnalytics(filtro.MontarQuery());
        }

        public List<RelatorioDTO> ListSellsProductReportSintetics(Filtro filtro)
        {
            return _repository.ListSellsProductReportSintetics(filtro.MontarQuery());
        }

        public List<RelatorioDTO> ListBuysProductReportAnalytics(Filtro filtro)
        {
            return _repository.ListBuysProductReportAnalytics(filtro.MontarQuery());
        }

        public List<RelatorioDTO> ListBuysProductReportSintetics(Filtro filtro)
        {
            return _repository.ListBuysProductReportSintetics(filtro.MontarQuery());
        }
    }
}

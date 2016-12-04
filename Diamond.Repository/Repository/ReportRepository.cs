using Diamond.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Repository.Repository
{
    public class ReportRepository
    {
        private DiamondContext _context = new DiamondContext();

        public List<RelatorioDTO> ListSellsProductReportAnalytics(string query)
        {
            return _context.Database.SqlQuery<RelatorioDTO>($"EXEC [dbo].[sp_sells_report_analytics_of_products] {query}").ToList();
        }

        public List<RelatorioDTO> ListSellsProductReportSintetics(string query)
        {
            return _context.Database.SqlQuery<RelatorioDTO>($"EXEC [dbo].[sp_sells_report_sintetic_of_products] {query}").ToList();
        }

        public List<RelatorioDTO> ListBuysProductReportAnalytics(string query)
        {
            return _context.Database.SqlQuery<RelatorioDTO>($"EXEC [dbo].[sp_buys_report_analytics_of_products] {query}").ToList();
        }

        public List<RelatorioDTO> ListBuysProductReportSintetics(string query)
        {
            return _context.Database.SqlQuery<RelatorioDTO>($"EXEC [dbo].[sp_buys_report_sintetics_of_products] {query}").ToList();
        }
    }
}

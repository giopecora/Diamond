using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Domain.Models
{
    public class Filtro
    {
        public DateTime? DataInicio { get; set; }
        public DateTime? DataTermino { get; set; }
        public string Produto { get; set; }
        public int? CategoriaId { get; set; }

        public string MontarQuery()
        {
            string query = "";

            if (DataInicio.HasValue)
                query += $"@Periodo_Inicial = '{DataInicio.Value}'";

            if (DataTermino.HasValue)
                query += (DataInicio.HasValue ? ", " : "") + $"@Periodo_Final = '{DataTermino.Value}'";

            if (!string.IsNullOrEmpty(Produto))
                query += (DataTermino.HasValue ? ", " : "") + $"@Produto = '{Produto}'";

            if (CategoriaId.HasValue)
                query += (!string.IsNullOrEmpty(Produto) ? ", " : "") + $"@CategoriaId = {CategoriaId}";

            return query;
        }
    }
}

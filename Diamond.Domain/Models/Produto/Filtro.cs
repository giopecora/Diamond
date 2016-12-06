using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Domain.Models.Produto
{
    public class Filtro
    {
        public string Produto { get; set; }
        public string Descricao { get; set; }
        public int? CategoriaId { get; set; }
        public bool Ativo { get; set; }

        public string MontarQuery()
        {
            string query = "";

            if (!string.IsNullOrEmpty(Produto))
                query += $"@Produto = '{Produto}'";

            if (!string.IsNullOrEmpty(Descricao))
                query += (!string.IsNullOrEmpty(Produto) ? ", " : "") + $"@Descricao = {Descricao}";

            if (CategoriaId.HasValue)
                query += (!string.IsNullOrEmpty(Descricao) ? ", " : "") + $"@CategoriaId = {CategoriaId}";

            query += (CategoriaId.HasValue ? ", " : "") + $"@Ativo = {Ativo}";

            return query;
        }
    }
}

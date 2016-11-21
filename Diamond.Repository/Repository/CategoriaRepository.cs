using Diamond.Domain.DTO.Categoria;
using Diamond.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Repository.Repository
{
    public class CategoriaRepository
    {
        private DiamondContext _context = new DiamondContext();

        public List<ProdutoCategoria> ListTop4ProductsOfAllCategories()
        {
            return _context.Database.SqlQuery<ProdutoCategoria>("EXEC [dbo].[sp_list_top_4_sells_of_every_category]").ToList();
        }
    }
}

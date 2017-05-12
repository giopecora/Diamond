using Diamond.Domain.DTO;
using Diamond.Domain.DTO.Categoria;
using Diamond.Domain.Entities;
using Diamond.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Business
{
    public class CategoriaBusiness
    {
        private CategoriaRepository _repository = new CategoriaRepository();

        public List<CategoriaDTO> ListTop8ProductsOfAllCategories()
        {
            List<CategoriaDTO> categorias = new List<CategoriaDTO>();
            List<ProdutoCategoria> entities = _repository.ListTopSellsProductsOfAllCategories();
            IEnumerable<int> ids = from e in entities
                            group e by e.Id into i
                            select i.Key;

            foreach(int id in ids)
            {
                List<ProdutoCategoria> entitiesByCat = entities.Where(e => e.Id == id).ToList();
                CategoriaDTO categoria = new CategoriaDTO()
                {
                    Id = id
                };

                foreach(ProdutoCategoria entity in entitiesByCat)
                {
                    categoria.Produtos.Add(new ProdutoDTO()
                    {
                        CategoriaId = id,
                        Id = entity.ProdutoId,
                        Descricao = entity.Descricao,
                        ImagemPrincipal = entity.ImagemPrincipal,
                        MarcaId = entity.MarcaId,
                        Nome = entity.Nome,
                        Preco = entity.Preco
                    });
                }

                categorias.Add(categoria);
            }

            return categorias;
        }
    }
}

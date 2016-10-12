using Diamond.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Domain.DTO
{
    public class ProdutoDTO
    {
        public ProdutoDTO()
        {

        }

        public ProdutoDTO(Produto entity)
        {
            Id = entity.ID_Produto;
            CategoriaId = entity.ID_Categoria;
            Nome = entity.NM_Produto;
            Descricao = entity.DS_produto;
            Imagem = entity.DS_imagem;
            Preco = entity.VL_preco;
            Quantidade = entity.NR_Quantidade_Estoque;
            Ativo = entity.FL_Ativo ?? false;
        }

        public Produto ToEntity()
        {
            return new Entities.Produto()
            {
                ID_Produto = Id,
                ID_Categoria = CategoriaId,
                NM_Produto = Nome,
                DS_produto = Descricao,
                DS_imagem = Imagem,
                VL_preco = Preco,
                NR_Quantidade_Estoque = Quantidade,
                FL_Ativo = Ativo
            };
        }

        public int Id { get; set; }
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public double? Preco { get; set; }
        public int? Quantidade { get; set; }
        public bool Ativo { get; set; }
    }
}

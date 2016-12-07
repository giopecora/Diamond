using Diamond.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Domain.DTO
{
    public class ProdutoDTO
    {
        public ProdutoDTO()
        {
            Imagens = new List<ProdutoImagemDTO>();
        }

        public int Id { get; set; }
        public int? CategoriaId { get; set; }
        public int MarcaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double? Preco { get; set; }
        public int? Quantidade { get; set; }
        public bool? Ativo { get; set; }

        public string ImagemPrincipal { get; set; }

        public string Action
        {
            get
            {
                string action = $"Home/AbrirImagem?produtoId={Id}&nome={ImagemPrincipal}";
                return $"http://localhost:59783/" + action;
            }
        }

        public List<ProdutoImagemDTO> Imagens { get; set; }
    }
}

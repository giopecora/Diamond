using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Domain.DTO
{
    public class ProdutoImagemDTO
    {
        public ProdutoImagemDTO()
        {

        }

        public int ProdutoId { get; set; }
        public string Imagem { get; set; }

        public string Action
        {
            get
            {
                string action = $"Home/AbrirImagem?produtoId={ProdutoId}&nome={Imagem}";
                return $"http://localhost:59783/" + action;
            }
        }
    }
}

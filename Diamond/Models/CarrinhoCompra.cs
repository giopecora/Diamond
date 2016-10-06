using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diamond.Models
{
    public class CarrinhoCompra
    {
        public string Imagem { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public double ValorUnitario { get; set; }
        public string ValorUnitarioTotal { get; set; }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Diamond.Models;

namespace Diamond.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AbrirImagem(int produtoId, string nome)
        {
            string mimeType = "";

            if (!string.IsNullOrEmpty(nome))
            {

                switch (nome.GetFileExtension())
                {
                    case ".jpg": mimeType = "image/jpg"; break;
                    case ".png": mimeType = "image/png"; break;
                }
            
                return File($@"C:/Produtos/Produto_{produtoId}/{nome}", mimeType);
            }
            return Content("");
        }

        public ActionResult CarrinhoCompra()
        {
            List<CarrinhoCompra> lista = new List<CarrinhoCompra>();

            lista.Add(new CarrinhoCompra()
            {
                Imagem = "/Content/img/liquidificador.jpg",
                Nome = "Liquidificador TX VB BLA",
                Descricao = "Liquidificar otimizado com 3 quartzos de rosa Juventa, serve para triturar coisas bem duras",
                Quantidade = 1,
                ValorUnitario = 78.90,
                ValorUnitarioTotal = "78,90"
            });

            lista.Add(new CarrinhoCompra()
            {
                Imagem = "/Content/img/memoriaRAM.jpg",
                Nome = "Memória RAM Kingston 8GB DDR3 UTF 8 JAJA",
                Descricao = "Memória RAM Kingston, excelente para jogos que exigem alto desempenho e performance",
                Quantidade = 1,
                ValorUnitario = 235.65,
                ValorUnitarioTotal = "235,65"
            });

            lista.Add(new CarrinhoCompra()
            {
                Imagem = "/Content/img/microondas.jpg",
                Nome = "Microondas Electrolux 1.8 TFF VGB COK",
                Descricao = "Microondas da Electrolux de última geração, suporta as tecnologias BurnTheCock, que faz com que os alimentos esquentem mais rapidamente.",
                Quantidade = 1,
                ValorUnitario = 230.80,
                ValorUnitarioTotal = "230,80"
            });

            lista.Add(new CarrinhoCompra()
            {
                Imagem = "/Content/img/relescopio.jpg",
                Nome = "Telescópio Luna 580 PF66 55mm",
                Descricao = "Telescópio com ótimo foco para enxergar a Lua, possui lentes que podem chegar até Marte!",
                Quantidade = 1,
                ValorUnitario = 640.90,
                ValorUnitarioTotal = "640,90"
            });

            lista.Add(new CarrinhoCompra()
            {
                Imagem = "/Content/img/televisão.jpg",
                Nome = "Televisão Samsung 32' Smart Screen, Smart Junk",
                Descricao = "Televisão Samsung Smart Screen e Phone, com suporte a vídeos de 4K e muito mais!",
                Quantidade = 1,
                ValorUnitario = 1200.90,
                ValorUnitarioTotal = "1200,90"
            });

            return View(lista);
        }
    }
}

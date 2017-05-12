using AutoMapper;
using Diamond.Domain.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diamond.App_Start
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new EnderecoProfile());
                cfg.AddProfile(new PedidoItemProfile());
                cfg.AddProfile(new PedidoProfile());
                cfg.AddProfile(new ProdutoProfile());
                cfg.AddProfile(new ProdutoImagemProfile());
                cfg.AddProfile(new UsuarioProfile());
                cfg.AddProfile(new UsuarioPerfilProfile());
                cfg.AddProfile(new CartaoProfile());
                cfg.AddProfile(new EstoqueEntradaProfile());
                cfg.AddProfile(new EstoqueSaidaProfile());
            });
        }
    }
}
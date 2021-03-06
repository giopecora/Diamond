﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;

namespace Diamond
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.elevateZoom-3.0.8.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.unobtrusive*",
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                "~/Scripts/knockout-{version}.js",
                "~/Scripts/knockout.validation.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/angular.min.js",
                "~/Scripts/angular-cookies.min.js",
                "~/Scripts/angular-route.min.js",
                "~/Scripts/ui-bootstrap-tpls-2.2.0.min.js",
                "~/Scripts/tmhDynamicLocale.min.js",
                "~/Scripts/angular-input-masks-standalone.js",
                "~/Scripts/angular-local-storage.min.js",
                "~/Scripts/ng-file-upload.min.js",
                "~/Scripts/angular-locale_pt-br.env.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js",
                "~/Scripts/ui-bootstrap-2.2.0.js"));

            bundles.Add(new ScriptBundle("~/bundles/SPA").Include(               
                "~/SPA/App.js",
                "~/SPA/locale.run.js",
                "~/SPA/Services/Util.js",
                "~/SPA/Services/LayoutCtrl.js",                
                "~/SPA/Produtos/Controllers/produtoDetalhe.js",
                "~/SPA/Produtos/Controllers/produtoListCateg.js",
                "~/SPA/Backoffice/Modals/Controllers/adicionar-produto.js",
                "~/SPA/Backoffice/Modals/Controllers/vizualizar-produto.js",
                "~/SPA/BackOffice/Controllers/back-office.js",
                "~/SPA/Backoffice/Controllers/manter-produto.js",                
                "~/SPA/Backoffice/Controllers/relatorioAnalitico.js",
                "~/SPA/Backoffice/Controllers/relatorioSintetico.js",
                "~/SPA/Home/Controllers/HomeController.js",
                "~/SPA/Carrinho/Controllers/mainCarrinho.js",
                "~/SPA/Pessoas/Controllers/cadastroUsuario.js",
                "~/SPA/Pessoas/Controllers/login.js",
                "~/SPA/Pessoas/Modals/Controllers/usuarioAlterarSenha.js",
                "~/SPA/Pessoas/Modals/Controllers/usuarioCartoes.js",
                "~/SPA/Pessoas/Modals/Controllers/usuarioEndereco.js",
                "~/SPA/Pessoas/Modals/Controllers/pedidoDetalhes.js",
                "~/SPA/Pessoas/Controllers/perfilUsuario.js",
                "~/SPA/Services/authInterceptorService.js",
                "~/SPA/Services/authService.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/Content/bootstrap.css",
                 "~/Content/Site.css",
                 "~/Content/font-awesome.min.css",
                 "~/SPA/Home/Style/HomeStyle.css"));
        }
    }
}

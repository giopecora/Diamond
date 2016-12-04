﻿var App = angular.module('Diamond', ['ngRoute', 'ui.bootstrap', 'ngCookies', 'ui.utils.masks']);

App.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when('/Home', {
            templateUrl: 'SPA/Home/Views/index.html',
            controller: 'HomeController'
        })
        .when('/Produtos', {
            templateUrl: 'SPA/Produtos/Views/produto.html',
            controller: 'ProdutoController'
        })
        .when('/Produtos/Cadastrar', {
            templateUrl: 'SPA/Produtos/Views/produtoCadastro.html',
            controller: 'ProdutoCadastroCtrl'
        })
        .when('/Produtos/:prodID', {
            templateUrl: 'SPA/Produtos/Views/produtoDetalhe.html',
            controller: 'ProdutoDetalheCtrl'
        })
        .when('/Categoria/:categoriaID', {
            templateUrl: 'SPA/Produtos/Views/produtoListCateg.html',
            controller: 'ProdutoCategoria'
        })
        .when('/CarrinhoCompra', {
            templateUrl: 'SPA/Carrinho/Views/mainCarrinho.html',
            controller: 'MainCarrinhoCtrl'
        })
        .when('/Produtos/listagem/:categoriaID', {
            templateUrl: 'SPA/Produtos/Views/produtoListCateg.html',
            controller: 'ProdutoCategoria'
        })
        .when('/CadastroUsuario', {
            templateUrl: 'SPA/Pessoas/Views/cadastroUsuario.html',
            controller: 'PessoasCadastro'
        })
        .when('/backoffice/produtos', {
            templateUrl: 'SPA/Produtos/Views/manter-produto.html',
            controller: ''
        })
        .when('/Login', {
            templateUrl: 'SPA/Pessoas/Views/login.html'
        })
        
    .otherwise({ redirectTo: '/Home' })
}])
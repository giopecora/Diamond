var App = angular.module('Diamond', ['ngRoute', 'ui.bootstrap']);

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
        .when('/CarrinhoCompra', {
            templateUrl: 'SPA/Carrinho/Views/mainCarrinho.html',
            controller: 'MainCarrinhoCtrl'
        })
    .otherwise({ redirectTo: '/Home' })
}])
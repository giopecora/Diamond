var App = angular.module('Diamond', ['ngRoute']);

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
        .when('/Produtos/primeiro', {
            templateUrl: 'SPA/Produtos/Views/produtoDetalhe.html',
            controller: 'ProdutoDetalheCtrl'
        })
    .otherwise({ redirectTo: '/Home' })
}])
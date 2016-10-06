var App = angular.module('Diamond', ['ngRoute', 'Produto']);

App.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when('/Home', {
        templateUrl: 'SPA/Home/Views/index.html'
        })
        .when('/Produtos', {
            templateUrl: 'SPA/Produtos/Views/produto.html',
            controller: 'ProdutoController'
        })
    .otherwise({ redirectTo: '/Home' })
}])
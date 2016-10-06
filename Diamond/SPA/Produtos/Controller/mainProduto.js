angular.module('Diamond')

    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/Produtos', {
            templateUrl: 'SPA/Produtos/Views/produto.html',
            controller: 'ProdutoController'
        })
        .when('/Produtos/primeiro', {
            templateUrl: 'SPA/Produtos/Views/ProdutoDetalhe.html'
        })
    }])

    .controller('ProdutoController', function($scope) {
        $scope.mensagem = "eita";
    });

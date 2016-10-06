angular.module('Produto', [])

    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/Produtos', {
            templateUrl: 'SPA/Produtos/Views/produto.html',
            controller: 'ProdutoController'
        })
        .when('/Produtos/primeiro', {
            templateUrl: 'SPA/Produtos/Views/produtoDetalhe.html',
            controller: 'ProdutoController'
        })
    }])

    .controller('ProdutoController', function($scope) {
        $scope.mensagem = "FOI MALUCO";
    });

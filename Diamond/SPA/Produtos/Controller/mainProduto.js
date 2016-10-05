angular.module('Diamond')

    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/Produtos', {
            templateUrl: 'SPA/Produtos/Views/produto.html',
            controller: 'ProdutoController'
        })
    }])

    .controller('ProdutoController', function($scope) {
        $scope.mensagem = "eita";
    });

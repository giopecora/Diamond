angular.module('Produto', [])

    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/Produtos/Cadastrar', {
            templateUrl: 'SPA/Produtos/Views/produtoCadastro.html',
            controller: 'ProdutoCadastroCtrl'
        })
        .when('/Produtos/primeiro', {
            templateUrl: 'SPA/Produtos/Views/produtoDetalhe.html',
            controller: 'ProdutoDetalheCtrl'
        })
    }]);

var App = angular.module('Diamond', ['ngRoute', 'ui.bootstrap', 'ngCookies', 'ui.utils.masks',
    'LocalStorageModule', 'tmh.dynamicLocale', 'ngFileUpload']);


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
        .when('/Produtos/:prodID', {
            templateUrl: 'SPA/Produtos/Views/produtoDetalhe.html',
            controller: 'ProdutoDetalheCtrl'
        })
        .when('/Produtos/listagem/:categoriaID', {
            templateUrl: 'SPA/Produtos/Views/produtoListCateg.html',
            controller: 'ProdutoCategoria'
        })
        .when('/Categoria/:categoriaID?:search?', {
            templateUrl: 'SPA/Produtos/Views/produtoListCateg.html',
            controller: 'ProdutoCategoria'
        })
        .when('/CarrinhoCompra', {
            templateUrl: 'SPA/Carrinho/Views/mainCarrinho.html',
            controller: 'MainCarrinhoCtrl'
        })
        .when('/CadastroUsuario', {
            templateUrl: 'SPA/Pessoas/Views/cadastroUsuario.html',
            controller: 'PessoasCadastro'
        })
        .when('/backoffice', {
            templateUrl: 'SPA/Backoffice/Views/back-office.html',
            controller: 'BackOfficeCtrl'
        })
        .when('/backoffice/produtos', {
            templateUrl: 'SPA/Backoffice/Views/manter-produto.html',
            controller: 'ManterProdutoCtrl'
        })
        .when('/backoffice/relatorio-analitico-produtos', {
            templateUrl: 'SPA/Backoffice/Views/relatorioAnalitico.html',
            controller: 'RelatorioAnaliticoCtrl'
        })
        .when('/backoffice/relatorio-sintetico-produtos', {
            templateUrl: 'SPA/Backoffice/Views/relatorioSintetico.html',
            controller: 'RelatorioSinteticoCtrl'
        })
        .when('/Login', {
            templateUrl: 'SPA/Pessoas/Views/login.html',
            controller: 'LoginCtrl'
        })
        .when('/Usuario/:usuarioID', {
            templateUrl: 'SPA/Pessoas/Views/perfilUsuario.html',
            controller: 'PerfilUsuarioCtrl'
        })

    .otherwise({ redirectTo: '/Home' })
}]);

App.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
    //$httpProvider.defaults.headers.common['Access-Control-Allow-Headers'] = '*';
});

App.run(['authService', function (authService) {
    authService.fillAuthData();
}]);

App.controller('MainCtrl', function (tmhDynamicLocale) {
    tmhDynamicLocale.set('pt-BR');
});
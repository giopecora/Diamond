angular.module('Diamond').controller('BackOfficeCtrl', function ($scope, ProdutoCategoriaService, $routeParams, $location) {
    
    $scope.load = function () {

    }

    $scope.AbrirProdutos = function () {
        $location.path("/backoffice/produtos");
    }

    $scope.AbrirRelatorioAnalitico = function () {
        $location.path("/backoffice/relatorio-analitico-produtos");
    }

    $scope.AbrirRelatorioSintetico = function () {
        $location.path("/backoffice/relatorio-sintetico-produtos");
    }

});
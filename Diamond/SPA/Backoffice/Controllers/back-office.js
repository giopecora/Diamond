angular.module('Diamond').controller('BackOfficeCtrl', function ($scope, ProdutoCategoriaService, $routeParams, $location) {
    
    //voce pode pegar o id do usuario pelo $routeParams



    $scope.load = function () {
        // Listar aqui os pedidos para o usuario
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

})
.service('backofficeService', function ($http) {
    return {
        //metodos aqui
    }
});
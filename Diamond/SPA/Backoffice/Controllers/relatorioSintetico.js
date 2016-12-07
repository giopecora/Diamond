angular.module('Diamond').controller('RelatorioSinteticoCtrl', function ($scope, RelatorioSinteticoService) {

    $scope.tipoRelatorio = "vendas";
    $scope.produtos = []
    $scope.titulo = "Vendas";
    $scope.filtro = {
        DataInicio: '',
        DataTermino: '',
        Produto: '',
        CategoriaId: ''
    };

    $scope.load = function () {

        $scope.filtrar();
    };

    $scope.filtrar = function () {

        Object.keys($scope.filtro).forEach(function (prop) {
            if ($scope.filtro[prop] === undefined) {
                $scope.filtro[prop] = '';
            }
        });

        var qs = "DataInicio=" + $scope.filtro.DataInicio + "&DataTermino=" + $scope.filtro.DataTermino +
                          "&Produto=" + $scope.filtro.Produto + "&CategoriaId=" + $scope.filtro.CategoriaId + "&page=1";

        if ($scope.tipoRelatorio !== "compras") {
            $scope.titulo = "Vendas";
            RelatorioSinteticoService.listProductSellsSintetics(qs).then(function (retorno) {
                $scope.produtos = retorno.data;
            }).catch(function () {
                //swal();
            });
        } else {
            $scope.titulo = "Compras";
            RelatorioSinteticoService.listProductBuysSintetics(qs).then(function (retorno) {
                $scope.produtos = retorno.data;
            }).catch(function () {
                //swal();
            });
        }
    };

    $scope.load();
})
.service('RelatorioSinteticoService', function ($http) {
    return {
        listProductSellsSintetics: function (qs) {
            return $http({
                method: 'GET',
                url: 'http://localhost:59783/api/Report/ProductSellsSintetics?' + qs
            });
        },
        listProductBuysSintetics: function (qs) {
            return $http({
                method: 'GET',
                url: 'http://localhost:59783/api/Report/ProductBuysSintetics?' + qs
            });
        }
    }
});
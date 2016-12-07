angular.module('Diamond').controller('RelatorioAnaliticoCtrl', function ($scope, $routeParams, RelatorioAnaliticoService) {

    $scope.tipoRelatorio = "vendas";
    $scope.titulo = "Vendas";
    $scope.filtro = {
        DataInicio: '',
        DataTermino: '',
        Produto: '',
        CategoriaId: ''
    };

    $scope.load = function () {
        $scope.tipoRelatorio = $routeParams.tipoRelatorio;
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
            RelatorioAnaliticoService.listProductSellsAnalytics(qs).then(function (retorno) {
                $scope.produtos = retorno.data;
            }).catch(function () {
                //swal();
            });
        } else {
            $scope.titulo = "Compras";
            RelatorioAnaliticoService.listProductBuyssAnalytics(qs).then(function (retorno) {
                $scope.produtos = retorno.data;
            }).catch(function () {
                //swal();
            });
        }
    };

    $scope.load();
})
.service('RelatorioAnaliticoService', function ($http) {
    return {
        listProductSellsAnalytics: function (qs) {
            return $http({
                method: 'GET',
                url: 'http://localhost:59783/api/Report/ProductSellsAnalytics?' + qs
            });
        },
        listProductBuyssAnalytics: function (qs) {
            return $http({
                method: 'GET',
                url: 'http://localhost:59783/api/Report/ProductBuysAnalytics?' + qs
            });
        }
    }
});
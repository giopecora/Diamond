angular.module('Diamond').controller('RelatorioAnaliticoCtrl', function ($scope, $routeParams, RelatorioAnaliticoService) {

    $scope.tipoRelatorio = "vendas";
    $scope.paginaAtual = 1;
    $scope.titulo = "Vendas";
    $scope.filtro = {
        DataInicio: '',
        DataTermino: '',
        Produto: '',
        CategoriaId: ''
    };

    $scope.load = function () {

        $scope.tipoRelatorio  = $routeParams.tipoRelatorio ? $routeParams.tipoRelatorio : "vendas";
        $scope.filtrar();
    };

    $scope.filtrar = function () {        

        var qs = "DataInicio=" + $scope.filtro.DataInicio + "&DataTermino=" + $scope.filtro.DataTermino +
                          "&Produto=" + $scope.filtro.Produto + "&CategoriaId=" + $scope.filtro.CategoriaId + "&page=1";

        if ($scope.tipoRelatorio != "compras") {
            $scope.titulo = "Vendas";
            RelatorioAnaliticoService.listProductSellsAnalytics(qs).then(function (retorno) {
                $scope.produtos = retorno.data;
                //Object.keys($scope.filtro).forEach(function (prop) {
                //    if ($scope.filtro[prop] === undefined) {
                //        $scope.filtro[prop] = '';
                //    }
                //});
            }).catch(function (retorno) {
                //swal();
                console.log();
            });
        } else {
            $scope.titulo = "Compras";
            RelatorioAnaliticoService.listProductBuyssAnalytics(qs).then(function (retorno) {
                $scope.produtos = retorno.data;
            }).catch(function (retorno) {
                //swal();
                console.log();
            });
        }
    };

    $scope.load();
})
.service('RelatorioAnaliticoService', function ($http, UtilService) {
    return {
        listProductSellsAnalytics: function (qs) {
            return $http({
                method: 'GET',
                url: UtilService.montarUrl('Report/ProductSellsAnalytics?' + qs)
            });
        },
        listProductBuyssAnalytics: function (qs) {
            return $http({
                method: 'GET',
                url: UtilService.montarUrl('Report/ProductBuysAnalytics?' + qs)
            });
        }
    }
});
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

        var params = $scope.filtro;
        params.paginaAtual = $scope.paginaAtual;

        if ($scope.tipoRelatorio != "compras") {
            $scope.titulo = "Vendas";
            RelatorioAnaliticoService.listProductSellsAnalytics(params).then(function (retorno) {
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
            RelatorioAnaliticoService.listProductBuyssAnalytics(params).then(function (retorno) {
                $scope.produtos = retorno.data;
            }).catch(function (retorno) {
                //swal();
                console.log();
            });
        }
    };

    $scope.load();
})
.service('RelatorioAnaliticoService', function ($http) {
    return {
        listProductSellsAnalytics: function (params) {
            return $http({
                method: 'GET',
                url: 'http://localhost:59783/api/Report/ProductSellsAnalytics',
                params: params
            });
        },
        listProductBuyssAnalytics: function (params) {
            return $http({
                method: 'GET',
                url: 'http://localhost:59783/api/Report/ProductBuysAnalytics' + qs
            });
        }
    }
});
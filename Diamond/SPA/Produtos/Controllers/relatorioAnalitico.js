angular.module('Diamond').controller('RelatorioAnaliticoCtrl', function ($scope, RelatorioAnaliticoService) {

    $scope.load = function () {
        RelatorioAnaliticoService.listProductSellsAnalytics().then(function (retorno) {
            $scope.produtos = retorno.data;
            console.log(retorno.data);
        }).catch(function () {
            //swal();
        });

        //RelatorioAnaliticoService.gettopFourofAllCategories().then(function (retorno) {
        //    console.log("funfou")
        //}).catch(function () {

        //})
    };

    $scope.load();
})
.service('RelatorioAnaliticoService', function ($http) {
    return {
        listProductSellsAnalytics: function () {
            return $http({
                method: 'GET',
                url: 'http://localhost:59783/api/Report/ProductSellsAnalytics?DataInicio=&DataTermino=&Produto=&CategoriaId='
            });
        },
        listProductBuyssAnalytics: function () {
            return $http({
                method: 'GET',
                url: 'http://localhost:59783/api/Report/ProductBuysAnalytics?DataInicio=&DataTermino=&Produto=&CategoriaId='
            });
        }
    }
});
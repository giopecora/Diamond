angular.module('Diamond').controller('RelatorioSinteticoCtrl', function ($scope, RelatorioSinteticoService) {

    $scope.load = function () {
        RelatorioSinteticoService.listProductSellsSintetics().then(function (retorno) {
            $scope.produtos = retorno.data;
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
.service('RelatorioSinteticoService', function ($http) {
    return {
        listProductSellsSintetics: function () {
            return $http({
                method: 'GET',
                url: 'http://localhost:59783/api/Report/ProductSellsSintetics?DataInicio=&DataTermino=&Produto=&CategoriaId='
            });
        },
        listProductBuysSintetics: function () {
            return $http({
                method: 'GET',
                url: 'http://localhost:59783/api/Report/ProductBuysSintetics?DataInicio=&DataTermino=&Produto=&CategoriaId='
            });
        }
    }
});
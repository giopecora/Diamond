angular.module('Diamond').controller('HomeController', function ($scope, HomeService, UtilService, $cookies, $location) {

    $scope.produtos = [];


    $scope.load = function () {
        HomeService.listTopFive().then(function (retorno) {
            $scope.destaquePrincipal = retorno.data[0];
            $scope.destaques = retorno.data.slice(1, 5);            
        }).catch(function () {
            swal();
        });

        HomeService.gettopEightofAllCategories().then(function (retorno) {
            console.log();
        }).catch(function () {

        })
    };

    $scope.exibirDetalhes = function (produto) {
        $location.path("/Produtos/" + produto.id);
    }

    

    $scope.load();
})

.service('HomeService', function ($http) {
    return {
        listTopFive: function () {
            return $http({
                method: 'GET',
                url: UtilService.montarUrl('Produto/GetTop5')
            });
        },
        gettopEightofAllCategories: function () {
            return $http({
                method: 'GET',
                url: UtilService.montarUrl('Categoria/ListTop8ProductsOfAllCategories/')
            });
        }
    }
});
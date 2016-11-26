angular.module('Diamond').controller('HomeController', function ($scope, HomeService, UtilService, $cookies) {

    $scope.load = function () {
        HomeService.listTopFive().then(function (retorno) {
            $scope.destaquePrincipal = retorno.data[0];
            $scope.destaquePrimeiraLinha = retorno.data.slice(1, 3);
            $scope.destaqueSegundaLinha = retorno.data.slice(3, 5);
        }).catch(function () {
            swal();
        });

        HomeService.gettopFourofAllCategories().then(function (retorno) {
            console.log("funfou")
        }).catch(function () {

        })
    };

    $scope.exibirDetalhes = function (produto) {
        window.location = "#/Produtos/" + produto.id;
        
    }

    $scope.slides = [
        {
            id: 1,
            image: '/Content/img/liquidificador.jpg'
        },
        {
            id: 2,
            image: '/Content/img/microondas.jpg'
        },
        {
            id: 3,
            image: '/Content/img/relescopio.jpg'
        }
    ];

    

    $scope.load();
})

.service('HomeService', function ($http) {
    return {
        listTopFive: function () {
            return $http({
                method: 'GET',
                url: 'http://localhost:59783/api/Produto/GetTop5'                
            });
        },
        gettopFourofAllCategories: function () {
            return $http({
                method: 'GET',
                url: 'http://localhost:59783/api/Categoria/ListTop4ProductsOfAllCategories/'
            });
        }
    }
});
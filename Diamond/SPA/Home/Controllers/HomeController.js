﻿angular.module('Diamond').controller('HomeController', function ($scope, HomeService, UtilService, $cookies, $location) {

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
        gettopEightofAllCategories: function () {
            return $http({
                method: 'GET',
                url: 'http://localhost:59783/api/Categoria/ListTop8ProductsOfAllCategories/'
            });
        }
    }
});
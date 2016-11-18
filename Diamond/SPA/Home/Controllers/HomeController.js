angular.module('Diamond').controller('HomeController', function ($scope, HomeService) {

    $scope.load = function () {
        HomeService.listTopFive().then(function (retorno) {
            $scope.destaques = retorno.data.data;
        }).catch(function () {
            console.log("deu ruim");
        });
    };

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
        }
    }
});
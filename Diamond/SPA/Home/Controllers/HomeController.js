angular.module('Diamond').controller('HomeController', function ($scope, HomeService) {
    $scope.destaques = [
        {
            nome: 'Sabre de luz',
            descricao: 'Sabre de luz do Darth Maulgus',
            preco: 20,
            imagem: '/Content/img/8ooCUho.jpg'
        },
        {
            nome: 'Sabre de luz',
            descricao: 'Sabre de luz do Darth Maulgus',
            preco: 20,
            imagem: '/Content/img/8ooCUho.jpg'
        },
        {
            nome: 'Sabre de luz',
            descricao: 'Sabre de luz do Darth Maulgus',
            preco: 20,
            imagem: '/Content/img/8ooCUho.jpg'
        }
    ];

    $scope.load = function () {
        HomeService.listTopFive().then(function (retorno) {
            $scope.Produtos = retorno.data.data;
        }).catch(function () {
            console.log("deu ruim");
        });
    };

    $scope.adicionarAoCarrinho = function () {

    }

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
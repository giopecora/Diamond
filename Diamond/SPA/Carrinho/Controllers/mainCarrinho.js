var app = angular.module('Diamond');
app.controller('MainCarrinhoCtrl', function ($scope, $cookies, UtilService, CarrinhoService) {
    
    $scope.produtos = [];
    $scope.subTotal = 0;

    $scope.load = function () {
        $scope.produtos = UtilService.obterProdutos();
        $scope.produtos.map(function (produto) {
            $scope.subTotal += produto.totalUnitario;
        })
    }

    $scope.finalizarCompra = function () {

        var params = {

        }


        UtilService.limparCarrinho();
    };
    $scope.load();
});

app.service('CarrinhoService', function ($http) {
    return {
        finalizarCompra: function (params) {
            return $http({
                method: 'post',
                url: 'http://localhost:59783/api/Pedido/Post',
                data: params
            })
        }
    }
});

$("img").elevateZoom();
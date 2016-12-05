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

    $scope.aumentarQtdproduto = function (produto) {
        produto.quantidade++;
        UtilService.atualizarQuantidade(produto);
    }
    
    $scope.diminuirQtdProduto = function (produto) {        
        if (produto.quantidade == 1) {            
            return
        }            
        produto.quantidade--;
        UtilService.atualizarQuantidade(produto);
    }

    $scope.remover = function (produto) {
        UtilService.removerDoCarrinho(produto);
        $scope.load();
    }

    $scope.finalizarCompra = function () {

        //verifica se o usuário está logado
        //caso, sim prossegue, se nao redireciona para pagina de cadastro


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
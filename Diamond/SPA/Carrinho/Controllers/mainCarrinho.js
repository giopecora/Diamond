var app = angular.module('Diamond');
app.controller('MainCarrinhoCtrl', function ($scope, $cookies, UtilService, CarrinhoService, authService) {
    
    $scope.produtos = [];
    $scope.subTotal = 0;

    $scope.load = function () {
        $scope.produtos = UtilService.obterProdutos();
    }

    $scope.atualizarSubtotal = function () {
        var soma = 0;
        $scope.produtos.forEach(function (produto) {
            soma += (produto.preco * produto.quantidade);
        })
        return soma;
    }

    $scope.aumentarQtdproduto = function (produto) {
        produto.quantidade++;
        produto.totalUnitario = produto.preco * produto.quantidade;
        UtilService.atualizarQuantidade(produto);
    }
    
    $scope.diminuirQtdProduto = function (produto) {
        if (produto.quantidade == 1) {            
            return
        }            
        produto.quantidade--;
        produto.totalUnitario = produto.preco * produto.quantidade;
        UtilService.atualizarQuantidade(produto);
    }

    $scope.remover = function (produto) {
        UtilService.removerDoCarrinho(produto);
        $scope.load();
    }

    $scope.finalizarCompra = function () {

        //verifica se o usuário está logado
        //caso, sim prossegue, se nao redireciona para pagina de cadastro/login

        if (authService.authentication.isAuth) {
            
        } else {
            $location.path("/Login");
        }


        //UtilService.limparCarrinho();
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
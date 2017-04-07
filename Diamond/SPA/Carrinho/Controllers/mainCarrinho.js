var app = angular.module('Diamond');
app.controller('MainCarrinhoCtrl', function ($scope, $cookies, UtilService, CarrinhoService, authService, $rootScope, UsuarioEnderecoService, UsuarioCartaoService) {
    
    $scope.produtos = [];
    $scope.enderecos = [];
    $scope.cartoes = [];
    $scope.subTotal = 0;
    $scope.passo = 1;

    $scope.load = function () {
        if($scope.passo == 1)
            $scope.produtos = UtilService.obterProdutos();
        if ($scope.passo == 2) {
            
            UsuarioEnderecoService.listarEnderecos().then(function (retorno) {
                $scope.enderecos = retorno.data
            });

        }
        if ($scope.passo == 3) {

            UsuarioCartaoService.listarCartoes().then(function (retorno) {
                $scope.cartoes = retorno.data
            });
        }
    }

    $scope.atualizarSubtotal = function () {
        var soma = 0;
        $scope.produtos.forEach(function (produto) {
            soma += (produto.preco * produto.quantidade);
        })
        return soma;
    }

    $scope.proximo = function () {
        $scope.passo++;
        $scope.load();
    }

    $scope.anterior = function () {
        $scope.passo--;
        $scope.load();
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
            $scope.SelecionarEndereco();
        } else {
            $location.path("/Login");
        }


        //UtilService.limparCarrinho();
    };
    $scope.load();
});

app.service('CarrinhoService', function ($http, UtilService) {
    return {
        finalizarCompra: function (params) {
            return $http({
                method: 'post',
                url: UtilService.montarUrl('Pedido/Post'),
                data: params
            })
        }
    }
});

$("img").elevateZoom();
var app = angular.module('Diamond');
app.controller('MainCarrinhoCtrl', function ($scope, $cookies, UtilService, CarrinhoService, authService,
    $rootScope, UsuarioEnderecoService, UsuarioCartaoService, $location) {
    
    $scope.produtos = [];
    $scope.enderecos = [];
    $scope.cartoes = [];
    $scope.subTotal = 0;
    $scope.passo = 1;
    $scope.authentication = authService.authentication;

    $scope.load = function () {

        $scope.produtos = UtilService.obterProdutos();

        if ($scope.authentication.isAuth) {

            UsuarioEnderecoService.listarEnderecos().then(function (retorno) {
                $scope.enderecos = retorno.data;

                $scope.enderecos.forEach(function (e) {
                    e.selecionado = false
                })
            });
        
            UsuarioCartaoService.listarCartoes().then(function (retorno) {
                $scope.cartoes = retorno.data

                $scope.cartoes.forEach(function (c) {
                    c.selecionado = false;
                })
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
        if ($scope.passo == 1 && !$scope.authentication.isAuth) {
            alert("Faça login antes de continuar!");
            return;
        }

        $scope.passo++;
    }

    $scope.anterior = function () {
        $scope.passo--;
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

        if ($scope.authentication.isAuth) {
            
            var itensPedido = $scope.produtos.map(function (p) {
                return {
                    ProdutoId: p.id,
                    Quantidade: p.quantidade,
                    ValorUnitario: p.preco,
                    ValorTotal: p.quantidade * p.preco
                }
            })

            var params = {
                enderecoId: $scope.enderecoSelecionado.id,
                cartaoId: $scope.cartaoSelecionado.id,
                itens: itensPedido,
                ValorTotal: $scope.atualizarSubtotal()
            }

            CarrinhoService.finalizarCompra(params).then(function () {
                alert('compra finalizada');
                UtilService.limparCarrinho();

                $location.path("/Usuario/" + $scope.authentication.userId);
                
                load();
            })
            
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
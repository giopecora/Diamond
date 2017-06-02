angular.module('Diamond').controller('UsuarioPedidoDetalhesCtrl', function ($scope, $uibModalInstance, UsuarioPedidoDetalhesService, getIdPedido) {

    $scope.idPedido = getIdPedido;

    $scope.pedido = {
        numeroCartao: 'XXXXXXXXXXX1255',
        endereco: 'Rua Professor Soriano Magalhães, 124 ap 44',
        itens: [
            { produto: 'TV Plasma ', quantidade: 1, valorTotal: 1500.99 },
            { produto: 'Bluray Transformers ', quantidade: 3, valorTotal: 349.99 },
            { produto: 'Celular Galaxy Y', quantidade: 1, valorTotal: 450.50 }
        ]
    };

    $scope.calcularValorTotal = function () {
        var valorTotal = 0;

        for (var i = 0; i < $scope.pedido.itens.length; i++) {
            valorTotal += $scope.pedido.itens[i].valorTotal;
        }

        return valorTotal;
    };

    $scope.fechar = function () {
        $uibModalInstance.close();
    };

    $scope.load = function () {
        UsuarioPedidoDetalhesService.buscarPedidoDetalhes($scope.idPedido).then(function (result) { 
            var tmpPedido = result.data;

            // pegar numero do cartao pelo id

            // pegar numero do endereco pelo id

            // fazer loop para pegar todos os produtos com determinado id

        })
    };

    $scope.load();

}).service('UsuarioPedidoDetalhesService', function ($http, UtilService) {
    return {
        buscarPedidoDetalhes: function (idPedido) {
            return $http({
                method: 'GET',
                url: UtilService.montarUrl('Pedido/GetById/' + idPedido)
            })
        },

        getCartaoByID: function (idCartao) {
            return $http({
                method: 'GET',
                url: UtilService.montarUrl('Cartao/Get/' + idCartao)
            })
        },

        getEnderecoByID: function (idEndereco) {
            return $http({
                method: 'GET',
                url: UtilService.montarUrl('Endereco/Get/' + idEndereco)
            })
        },

        getProdutoByID: function (idProduto) {
            return $http({
                method: 'GET',
                url: UtilService.montarUrl('Produto/Get/' + idProduto)
            })
        }
    }
});
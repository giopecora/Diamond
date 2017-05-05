angular.module('Diamond').controller('UsuarioPedidoDetalhesCtrl', function ($scope, $uibModalInstance, UsuarioCartaoService) {

    $scope.pedido = {
        numeroCartao: 'XXXXXXXXXXX1255',
        endereco: 'Rua Professor Soriano Magalhães, 124 ap 44',
        itens: [
            { produto: 'TV Plasma meu PAU', quantidade: 1, valorTotal: 1500.99 },
            { produto: 'Bluray Transformers Brazzers', quantidade: 3, valorTotal: 349.99 },
            { produto: 'Fantasia de Codorna', quantidade: 1, valorTotal: 450.50 }
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
        $uibModalInstance.dismiss('cancel');
    };

    $scope.load = function () {
        //UsuarioCartaoService.buscarPedidoDetalhes().then(function (retorno) {
        //    $scope.cartoes = retorno.data
        //})
    };

    $scope.load();
}).service('UsuarioPedidoDetalhesService', function ($http, authService, UtilService) {
    return {
        buscarPedidoDetalhes: function () {
            return $http({
                method: 'GET',
                url: UtilService.montarUrl('Pedido/GetDetailed')
            })
        }        
    }
});
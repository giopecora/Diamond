angular.module('Diamond').controller('ProdutoDetalheCtrl', function ($scope, ProdutoService, $routeParams, UtilService) {
    $scope.prodID = $routeParams.prodID;

    $scope.load = function () {
        ProdutoService.productDetails($scope.prodID).then(function (retorno) {
            $scope.produto = retorno.data;
        }).catch(function () {
            //Tratar erro aqui
        })
    };

    $scope.adicionarCarrinho = function (produto) {
        UtilService.adicionarAoCarrinho(produto);
    }

    ProdutoService.inserir().then(function () {
        window.alert("Deu certo!")
    }).catch(function () {
        console.log("Deu ruim")
    });

    $scope.load();

})
.service('ProdutoService', function ($http) {
    return {
        productDetails: function(prodID) {
            return $http({
                method: 'GET',
                url: 'http://localhost:59783/api/Produto/Get/'+prodID
            });
        },

        inserir: function () {
            return $http({
                method: 'POST',
                url: 'http://localhost:59783/api/Pedido/Post',
                data: {
                    UsuarioId: 1,
                    CartaoId: 1,
                    EnderecoId: 1,
                    DataPedido: "2016-11-17 03:00:00",
                    ValorTotal: 870.00,
                    Itens: [
                     {
                         ProdutoId: 1,
                         Quantidade: 2,
                         ValorUnitarioTotal: 200.00
                     },
                     {
                         ProdutoId: 3,
                         Quantidade: 4,
                         ValorUnitarioTotal: 450.00
                     },
                     {
                         ProdutoId: 5,
                         Quantidade: 2,
                         ValorUnitarioTotal: 200.00
                     }
                    ]
                }
            });
        }
    };
})
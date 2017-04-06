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


    $scope.load();

})
.service('ProdutoService', function ($http) {
    return {
        productDetails: function(prodID) {
            return $http({
                method: 'GET',
                url: UtilService.montarUrl('Produto/Get/' + prodID)
            });
        }
    };
})
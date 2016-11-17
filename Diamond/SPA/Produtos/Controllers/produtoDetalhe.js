angular.module('Diamond').controller('ProdutoDetalheCtrl', function ($scope, ProdutoService, $routeParams) {
    $scope.prodID = $routeParams.prodID;

    $scope.load = function () {
        ProdutoService.productDetails($scope.prodID).then(function (retorno) {
            $scope.produto = retorno.data.data;
        }).catch(function () {
            //Tratar erro aqui
        })
    };

    $scope.load();

})
.service('ProdutoService', function ($http) {
    return {
        productDetails: function(prodID) {
            return $http({
                method: 'GET',
                url: 'http://localhost:59783/api/Produto/Get/'+prodID
            });
        }
    };
})
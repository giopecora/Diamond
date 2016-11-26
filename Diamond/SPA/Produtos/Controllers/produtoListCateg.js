angular.module('Diamond').controller('ProdutoCategoria', function ($scope, ProdutoService, $routeParams) {
    $scope.categoriaID = $routeParams.categoriaID;

    $scope.load - function () {
        ProdutoService.getProdutos($scope.categoriaID).then(function (retorno) {
            $scope.Produtos = retorno.data
        }).catch(function () { });
    }
})
.service('ProdutoCategoriaService', function ($http) {
    return {
        getProdutos: function (idCategoria) {
            return $http({
                method: 'GET',
                url: "http://localhost:59783/api/Produto/GetAllFromCategory/"+idCategoria/1
            });
        }
    }
})
;
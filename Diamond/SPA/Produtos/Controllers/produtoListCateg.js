angular.module('Diamond').controller('ProdutoCategoria', function ($scope, ProdutoService, $routeParams) {
    $scope.categoriaID = $routeParams.categoriaID;

    $scope.load - function () {

    }
})
.service('ProdutoCategoriaService', function ($http) {
    return {
        getProdutos: function (idCategoria) {
            return $http({
                method: 'GET',
                url: ''
            });
        }
    }
})
;
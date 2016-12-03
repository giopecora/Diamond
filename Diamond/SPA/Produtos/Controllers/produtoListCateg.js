angular.module('Diamond').controller('ProdutoCategoria', function ($scope, ProdutoCategoriaService, $routeParams, $location) {
    $scope.categoriaID = $routeParams.categoriaID;
    $scope.Produtos = [];
    $scope.categoria = "";

    $scope.load = function () {
        ProdutoCategoriaService.getProdutos($scope.categoriaID).then(function (retorno) {
            $scope.Produtos = retorno.data
        }).catch(function () { });

        switch ($scope.categoriaID) {
            case '1':
                $scope.categoria = "DVDs e Blu-ray";
                break;
            case '2':
                $scope.categoria = "Games";
                break;
            case '3':
                $scope.categoria = "Celulares e Telefonia Fixa";
                break;
            case '4':
                $scope.categoria = "Informática e Tablets";
                break;
            case '5':
                $scope.categoria = "Tv, Aúdio e Home Theater";
                break;
        }
    }

    $scope.exibirDetalhes = function (produto) {
        $location.path("/Produtos/"+produto.id);
    }

    $scope.load();
})
.service('ProdutoCategoriaService', function ($http) {
    return {
        getProdutos: function (idCategoria) {
            return $http({
                method: 'GET',
                url: "http://localhost:59783/api/Produto/GetAllFromCategory/"+idCategoria+"/1"
            });
        }
    }
})
;
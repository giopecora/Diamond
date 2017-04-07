angular.module('Diamond').controller('ProdutoCategoria', function ($scope, ProdutoCategoriaService, $routeParams, $location, SearchService) {
    $scope.categoriaID = $routeParams.categoriaID;

    $scope.Produtos = [];
    $scope.categoria = "";   

    $scope.load = function () {

        if ($scope.categoriaID) {
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



    }

    $scope.exibirDetalhes = function (produto) {
        $location.path("/Produtos/"+produto.id);
    }

    $scope.actions = {
        updateProducts: function (newProducts) {
            $scope.Produtos = newProducts;
        },


        search: function(search){
            SearchService.search(search)
                .then(function(response){
                    $scope.Produtos = response.data;
                });
        }
    }

    $scope.load();

    // Initialize
    $scope.$on('produto-categoria:update-products', $scope.actions.updateProducts);
    if ($routeParams.search) {
        $scope.actions.search($routeParams.search);
    }
})
.service('ProdutoCategoriaService', function ($http, UtilService) {
    return {
        getProdutos: function (idCategoria) {
            return $http({
                method: 'GET',
                url: UtilService.montarUrl('Produto/GetAllFromCategory/' + idCategoria + '/1')
            });
        }
    }
})
;
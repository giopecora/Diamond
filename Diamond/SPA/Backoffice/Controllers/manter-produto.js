angular.module('Diamond').controller('ManterProdutoCtrl', function ($scope, $uibModal, ManterProdutoService) {

    $scope.produtos = []
    $scope.produtoDetalhado = {};

    $scope.load = function () {

    }


    $scope.abrirDetalhesProduto = function (idProduto) {
        var modalInstance = $uibModal.open({
            templateUrl: './SPA/Backoffice/Modals/Views/vizualizar-produto.html',
            controller: 'ProdutoVisualizarCtrl',
            backdrop: 'static',
            size: 'lg',
            resolve :{
                getIdProduto: function(){
                    return idProduto;
                }
            }
        });
    }

    $scope.abrirAdicionarProduto = function () {

        var modalInstance = $uibModal.open({
            templateUrl: './SPA/Backoffice/Modals/Views/adicionar-produto.html',
            controller: 'ProdutoCadastroCtrl',
            backdrop: 'static',
            size: 'lg',
            resolve: {
                //passar funções aqui
            }
        });

        modalInstance.result.then(function (produtoCadastrado) {
            $scope.abrirDetalhesProduto(produtoCadastrado.id);
        })
    };
})
.service('ManterProdutoService', function ($http) {
    return {
        cadastrarProduto: function(params){
            return $http({
                method: 'POST',
                url: 'http://localhost:59783/api/Produto/Post',
                data: params
            })
        },
        bucarProdutos: function () {

        },
        getProduto: function (ProdutoID) {
            return $http({
                method: 'GET',
                url: 'http://localhost:59783/api/Produto/Get'+ProdutoID
            })
        }
    }
});
angular.module('Diamond').controller('ManterProdutoCtrl', function ($scope, $uibModal) {


    $scope.load = function () {

    }

    $scope.salvar = function () {

    }

    $scope.abrirAdicionarProduto = function () {
        var modalInstance = $uibModal.open({
            templateUrl: './SPA/Produtos/Modals/Views/adicionar-produto.html',
            controller: 'ProdutoCadastroCtrl',
            backdrop: 'static',
            size: 'lg',
            resolve: {
                //passar funções aqui
            }
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

        }
    }
});
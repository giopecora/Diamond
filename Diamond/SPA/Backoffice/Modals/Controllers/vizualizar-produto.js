angular.module('Diamond').controller('ProdutoVisualizarCtrl', function ($scope, $uibModalInstance, Upload, ManterProdutoService) {

    $scope.editando = false;
    $scope.produto = {}

    $scope.fechar = function () {
        $uibModalInstance.dismiss('cancel');
    };


    $scope.load = function () {
        ManterProdutoService.getProduto($scope.produtoID).then(function (retorno) {
            $scope.produto = retorno.data;
        });
    }


    $scope.editar = function () {
        $scope.editando = true;
    }

    $scope.UploadImagem = function () {

    }

});
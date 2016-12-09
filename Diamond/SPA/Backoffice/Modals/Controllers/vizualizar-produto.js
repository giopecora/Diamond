angular.module('Diamond').controller('ProdutoVisualizarCtrl', function ($scope, $uibModalInstance, getIdProduto, Upload, ManterProdutoService) {

    $scope.produtoID = getIdProduto;

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

    $scope.salvar = function () {
        $uibModalInstance.close(true, $scope.produto);
    }


    $scope.editar = function () {
        $scope.editando = true;
    }

    $scope.UploadImagem = function () {

    }


    $scope.load();

});
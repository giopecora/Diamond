angular.module('Diamond').controller('ProdutoVisualizarCtrl', function ($scope, $uibModalInstance, getIdProduto, Upload, ManterProdutoService, isNovo) {

    $scope.produtoID = getIdProduto;

    $scope.editando = false;
    if (isNovo)
        $scope.editando = true;

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
        $uibModalInstance.close($scope.produto);
    }


    $scope.editar = function () {
        $scope.editando = true;
    }

    $scope.UploadImagem = function (file) {
        ManterProdutoService.uploadProduto($scope.produto.id, file).then(function (result) {
            console.log('upload concluido' + result);
        });

    }


    $scope.load();


});
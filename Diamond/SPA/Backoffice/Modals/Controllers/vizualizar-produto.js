angular.module('Diamond').controller('ProdutoVisualizarCtrl', function ($scope, $uibModalInstance, getIdProduto, Upload, ManterProdutoService, isNovo, UtilService) {

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

        var params = {
            url: UtilService.montarUrl('Produto/Upload?produtoId=' + $scope.produtoID),
            data: { file: file }
        }

        window.setTimeout(function(){
            Upload.upload(params).then(function () {
                console.log('upload ok');
            });
        }, 500);

        

    }


    $scope.load();


});
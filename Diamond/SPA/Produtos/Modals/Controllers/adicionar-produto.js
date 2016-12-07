angular.module('Diamond').controller('ProdutoCadastroCtrl', function ($scope, $routeParams, $location, Upload, ManterProdutoService) {

    $scope.novoProduto = {}

    $scope.fechar = function () {
        modalInstance.dismiss('cancel');
    };

    



    //SOMENTE APÓS PRODUTO CADASTRADO
    $scope.uploadFiles = function (files) {
        $scope.files = files;
        if (files && files.length) {
            Upload.upload({
                url: '',
                data: {
                    files: files
                }
            }).then(function (retorno) {
                //tratar aqui
            })
        }
    }
});
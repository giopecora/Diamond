angular.module('Diamond').controller('ProdutoCadastroCtrl', function ($scope, $routeParams, $uibModalInstance, $location, Upload, ManterProdutoService) {

    $scope.novoProduto = {
        Categoria: '',
        Nome: '',
        Descricao: '',
        preco: '',
        Ativo: false
    }

    $scope.fechar = function () {
        $uibModalInstance.dismiss('cancel');
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
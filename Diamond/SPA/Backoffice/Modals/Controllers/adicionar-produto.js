angular.module('Diamond').controller('ProdutoCadastroCtrl', function ($scope, $routeParams, $uibModalInstance, $location, Upload, ManterProdutoService) {

    $scope.novoProduto = {
        CategoriaID: 0,
        Nome: '',
        Descricao: '',
        preco: '',
        Ativo: false
    }

    $scope.fechar = function () {
        $uibModalInstance.dismiss('cancel');
    };

    $scope.salvar = function () {

        if ($scope.novoProduto.CategoriaID == 0) {
            alert("Selecione a Categoria do produto!");
            return;
        }

        if ($scope.novoProduto.Nome == '') {
            alert("Informe o nome do produto");
            return
        }

        if ($scope.novoProduto.preco == '') {
            alert("Indique o preço do produto!");
            return;
        }

        var tmpProduto = JSON.stringify($scope.novoProduto);

        ManterProdutoService.cadastrarProduto(tmpProduto).then(function (retorno) {
            alert("Produto cadastrado com sucesso!");
            $uibModalInstance.close(retorno.data);
        }, function () {
            alert("Erro ao cadastrar Produto!");
        }).catch(function (retorno) {
            alert("Erro inesperado!")
        })
    }



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
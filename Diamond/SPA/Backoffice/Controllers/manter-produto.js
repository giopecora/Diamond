angular.module('Diamond').controller('ManterProdutoCtrl', function ($scope, $uibModal, ManterProdutoService) {

    $scope.produtos = [];
    $scope.pages = [];
    $scope.currentPage = 0;
    $scope.produtoDetalhado = {};

    $scope.load = function () {

        getPages();

        ManterProdutoService.bucarProdutos(0).then(function (response) {
            $scope.produtos = response.data;
        });
    }

    $scope.findProducts = function (page, name) {
        if (!!name) {
            ManterProdutoService.bucarProdutosPorNome(page, name).then(function (response) {
                $scope.produtos = response.data;
                $scope.currentPage = page;
                getPages(name);
            });
        } else {
            ManterProdutoService.bucarProdutos(page).then(function (response) {
                getPages();
                $scope.currentPage = page;
                $scope.produtos = response.data;
            });
        }
    }

    $scope.abrirDetalhesProduto = function (idProduto, novo) {
        var modalInstance = $uibModal.open({
            templateUrl: './SPA/Backoffice/Modals/Views/visualizar-produto.html',
            controller: 'ProdutoVisualizarCtrl',
            backdrop: 'static',
            size: 'lg',
            resolve: {
                getIdProduto: function () {
                    return idProduto;
                },
                isNovo: function () {
                    return novo;
                }
            }
        });


        modalInstance.result.then(function (produto) {
            if (produto) {
                var tmpProduto = JSON.stringify(produto);
                ManterProdutoService.salvarProduto(tmpProduto).then(function (retorno) {
                    alert("Produto Salvo com sucesso!");
                })
            }
        })

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

        modalInstance.result.then(function (produto) {
            $scope.abrirDetalhesProduto(produto.id, true);
        });
    };

    function getPages(name) {
        $scope.pages = [];

        if (!!name) {
            ManterProdutoService.getCountByName(name).then(function (response) {
                var pages = Math.ceil(response.data[0] / 10);

                for (var i = 1; i <= pages; i++) {
                    $scope.pages.push(i);
                }
            });
        } else {
            ManterProdutoService.getCount().then(function (response) {
                var pages = Math.ceil(response.data[0] / 10);

                for (var i = 1; i <= pages; i++) {
                    $scope.pages.push(i);
                }
            });
        }

    };

    $scope.load();
})
.service('ManterProdutoService', function ($http) {
    return {
        cadastrarProduto: function (params) {
            return $http({
                method: 'POST',
                url: 'http://localhost:59783/api/Produto/Post',
                data: params
            })
        },
        bucarProdutos: function (page) {
            return $http({
                method: 'GET',
                url: 'http://localhost:59783/api/Produto/ListAll/' + page
            })
        },
        bucarProdutosPorNome: function (page, name) {
            return $http({
                method: 'GET',
                url: 'http://localhost:59783/api/Produto/ListAllByName/' + page + '/' + name
            })
        },
        getProduto: function (ProdutoID) {
            return $http({
                method: 'GET',
                url: 'http://localhost:59783/api/Produto/Get/' + ProdutoID
            })
        },
        getCount: function () {
            return $http({
                method: 'GET',
                url: 'http://localhost:59783/api/Produto/GetCount'
            });
        },
        getCountByName: function (name) {
            return $http({
                method: 'GET',
                url: 'http://localhost:59783/api/Produto/GetCountByName/' + name
            });
        },
        salvarProduto: function (produto) {
            return $http({
                method : 'PUT',
                url: 'http://localhost:59783/api/Produto/Put',
                data: produto
            })
        }
    }
});
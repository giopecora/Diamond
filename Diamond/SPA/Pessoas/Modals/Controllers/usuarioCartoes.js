﻿angular.module('Diamond').controller('UsuarioCartoesCtrl', function ($scope, $uibModalInstance, UsuarioCartaoService) {

    $scope.cartoes = [];
    $scope.formCartao = {
        bandeiraId: 0   ,
        numero: '',
        nome: '',
        vencimento: '',
        ccr: ''
    }

    $scope.novoCartao = false;

    $scope.fechar = function () {
        $uibModalInstance.close();
    };

    $scope.load = function () {
        UsuarioCartaoService.listarCartoes().then(function (retorno) {
            $scope.cartoes = retorno.data
        })
    };

    $scope.removerCartao = function (cartaoID) {
        if (window.confirm("Deseja Excluir o cartao?")) {
            UsuarioCartaoService.excluirCartao(cartaoID).then(function (retorno) {
                var index = $scope.cartoes.findIndex(function (cartao) {
                    return cartao.id = retorno.data.id;
                });

                $scope.cartoes.splice(index, 1);
            })
        }
    };

    $scope.abrirAdicionarCartao = function () {
        $scope.novoCartao = true;
    }

    $scope.salvarNovoCartao = function () {
        var tmpCartao = JSON.stringify($scope.formCartao);

        UsuarioCartaoService.salvarNovoCartao(tmpCartao).then(function (retorno) {
            var cartaoCadastrado = retorno.data
            $scope.cartoes.splice(0, 0, cartaoCadastrado);
            alert("Novo cartao cadastrado com sucesso!");


            //limpa os campos
            Object.keys($scope.formCartao).forEach(function (prop) {
                $scope.formCartao[prop] = '';
            });

            $scope.novoCartao = false;
        })

    };

    $scope.load();
}).service('UsuarioCartaoService', function ($http, authService, UtilService) {
    return {
        listarCartoes: function () {
            return $http({
                method: 'GET',
                url: UtilService.montarUrl('Cartao/GetAllFromUser')
            })
        },
        excluirCartao: function (cartaoID) {
            return $http({
                method: 'DELETE',
                url: UtilService.montarUrl('Cartao/Delete/' + cartaoID)
            })
        },
        salvarNovoCartao: function (novoCartao) {
            return $http({
                method: 'POST',
                url: UtilService.montarUrl('Cartao/Post'),
                data: novoCartao
            })
        }
    }
});
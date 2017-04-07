var app = angular.module('Diamond');
app.controller('PerfilUsuarioCtrl', function ($scope, UtilService, PerfilUsuarioService, $routeParams, $uibModal, authService) {
    
    $scope.usuarioID = $routeParams.usuarioID;
    $scope.usuario = {};
    $scope.pedidos = [];
    $scope.paginaAtual = 1;

    $scope.load = function () {
        PerfilUsuarioService.buscarPerfilUsuario($scope.usuarioID).then(function (retorno) {
            $scope.usuario = retorno.data;
        });

        PerfilUsuarioService.listarPedidosUsuario($scope.usuarioID, $scope.paginaAtual).then(function (retorno) {
            $scope.pedidos = retorno.data
        });
    };


    $scope.abrirEnderecos = function () {
        var modalInstance = $uibModal.open({
            templateUrl: './SPA/Pessoas/Modals/Views/usuarioEndereco.html',
            controller: 'UsuarioEnderecoCtrl',
            backdrop: 'static',
            size: 'lg',
            resolve: {
                getUsuario: function () {
                    return $scope.usuario;
                }
            }
        })
     
    };


    $scope.abrirCartoes = function () {
        var modalInstante = $uibModal.open({
            templateUrl: './SPA/Pessoas/Modals/Views/usuarioCartoes.html',
            controller: 'UsuarioCartoesCtrl',
            backdrop: 'static',
            size: 'lg',
            resolve: {
                getUsuario: function () {
                    return $scope.usuario;
                }
            }
        });
    }


    $scope.abrirAlterarSenha = function () {
        var modalInstance = $uibModal.open({
            templateUrl: './SPA/Pessoas/Modals/Views/usuarioAlterarSenha.html',
            controller: '',
            backdrop: 'static',
            size: 'sm',
        });
    };

    $scope.load();

})
.service('PerfilUsuarioService', function ($http, authService, UtilService) {
    return {
        buscarPerfilUsuario: function (UsuarioID) {
            return $http({
                method: 'GET',
                url: UtilService.montarUrl('Usuario/Get/')
            })
        },

        listarPedidosUsuario: function (usuarioID, paginaAtual) {
            return $http({
                method: 'GET',
                url: UtilService.montarUrl('Pedido/GetAllFromUser/' + paginaAtual)
            })
        }
    }
});
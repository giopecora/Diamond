var app = angular.module('Diamond');
app.controller('PerfilUsuarioCtrl', function ($scope, UtilService, PerfilUsuarioService, $routeParams, $uibModal) {
    
    $scope.usuarioID = $routeParams.usuarioID;
    $scope.usuario = {};
    $scope.pedidos = [];
    $scope.paginaAtual = 1;

    $scope.load = function () {
        PerfilUsuarioService.buscarPerfilUsuario($scope.usuarioID).then(function (retorno) {
            $scope.usuario = retorno.data;
        })

        PerfilUsuarioService.listarPedidosUsuario($scope.usuarioID, $scope.paginaAtual).then(function (retorno) {
            $scope.pedidos = retorno.data
        })
    };


    $scope.abrirEnderecos = function () {
        var modalInstance = $uibModal.open({
            templateUrl: './SPA/Pessoas/Modals/Views/usuarioEndereco.html',
            controller: 'UsuarioEnderecoCtrl',
            backdrop: 'static',
            size: 'lg',
            resolve: {

            }
        })
    };

    $scope.abrirAlterarSenha = function () {
        var modalInstance = $uibModal.open({
            templateUrl: './SPA/Pessoas/Modals/Views/usuarioAlterarSenha.html',
            controller: 'UsuarioEnderecoCtrl',
            backdrop: 'static',
            size: 'sm',
        });
    };

    $scope.load();

})
.service('PerfilUsuarioService', function ($http) {
    return {
        buscarPerfilUsuario: function (UsuarioID) {
            return $http({
                method: 'GET',
                url: 'http://localhost:59783/api/Usuario/Get/' + UsuarioID
            })
        },

        listarPedidosUsuario: function (usuarioID, paginaAtual) {
            return $http({
                method: 'GET',
                url: 'http://localhost:59783/api/Pedido/GetAllFromUser/' + usuarioID + '/' + paginaAtual
            })
        }
    }
});
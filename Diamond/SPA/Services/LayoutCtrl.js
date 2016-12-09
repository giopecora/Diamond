var app = angular.module('Diamond');
app.controller('LayoutCtrl', function ($scope, $cookies, UtilService, CarrinhoService, $timeout, SearchService, $location) {

    $scope.searchDebounce = null;
    $scope.search = null;

    //trazer perfil deusuario aqui
    $scope.perfilUsuario;

    $scope.actions = {
        search: function () {
            if ($scope.searchDebounce) {
                $timeout.cancel($scope.searchDebounce);
            }

            $scope.searchDebounce = $timeout(function () {
                if ($scope.search)
                    $location.url('/Categoria?search=' + $scope.search);
            }, 300);
        }
    };


    $scope.abrirMinhaConta = function () {
        if ($scope.perfilUsuario) {
            $location.path("/usuario/"+$scope.perfilUsuario.UsuarioID);
        } else {
            $location.path("/CadastroUsuario");
        }
    }
    
})
    .service('SearchService', function ($http) {
        return {
            search: function (search) {
                return $http({
                    method: 'POST',
                    url: 'http://localhost:59783/api/Produto/SearchForProducts/' + search
                });
            }
        }
    });
var app = angular.module('Diamond');
app.controller('LayoutCtrl', function ($scope, $cookies, UtilService, CarrinhoService, $timeout, SearchService, authService, $location, $window, $rootScope ) {

    $scope.searchDebounce = null;
    $scope.search = null;
    $scope.authentication = authService.authentication;

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

    $scope.deslogar = function () {
        authService.logOut();
        $location.path('/Home');
    }


    $scope.abrirMinhaConta = function () {
        if (authService.authentication.isAuth) {
            $location.path("/Usuario/" + authService.authentication.userId);
        }
    }

    $scope.irLogin = function () {
        $location.path("/Login");
    }

    
    
})
    .service('SearchService', function ($http, UtilService) {
        return {
            search: function (search) {
                return $http({
                    method: 'POST',
                    url: UtilService.montarUrl('Produto/SearchForProducts/' + search)
                });
            }
        }
    });
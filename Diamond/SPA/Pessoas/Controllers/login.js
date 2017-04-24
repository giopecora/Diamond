'use strict';
angular.module('Diamond').controller('LoginCtrl', ["$scope", "$location", 'authService', '$rootScope', 'localStorageService', function ($scope, $location, authService, $rootScope, localStorageService) {
    
    if (authService.authentication.isAuth) {
        //dar um jeito de impedir que o usuário acesse essa pagina
        //a ideia é redirecionar o usuário caso já esteja autenticado
        //$location.path('/Usuario/'+);
        $location.path('/Home');
    }
    
    $scope.loginData = {
        userName: "",
        password: ""
    };

    $scope.logar = function () {
        authService.login($scope.loginData).then(function (response) {
            
            //preciso receber o nome do cara;
            
            $location.path('/Home');
        },
        function (err) {
            $scope.message = err.error_description;
            alert($scope.message);
            $scope.loginData.userName = "";
            $scope.loginData.password = "";
        });
    };
}]);
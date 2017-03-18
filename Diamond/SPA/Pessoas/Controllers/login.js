'use strict';
angular.module('Diamond').controller('LoginCtrl', ["$scope", "$location", 'authService', '$rootScope', function ($scope, $location, authService, $rootScope) {
    $scope.message = "";
    $scope.loginData = {
        userName: "",
        password: ""
    };

    $scope.logar = function () {
        authService.login($scope.loginData).then(function (response) {
            
            alert("Usuário Logado!");
            //preciso receber o nome do cara;
            $rootScope.currentUser = {
                token: response.access_token
            };
            $location.path('/Home');
        },
        function (err) {
            $scope.message = err.error_description;
        });
    };
}]);
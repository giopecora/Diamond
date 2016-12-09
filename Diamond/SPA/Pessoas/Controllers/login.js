'use strict';
angular.module('Diamond').controller('LoginCtrl', ["$scope", "$location", 'authService', function ($scope, $location, authService) {
    $scope.message = "";
    $scope.loginData = {
        userName: "",
        password: ""
    };

    $scope.logar = function () {
        authService.login($scope.loginData).then(function (response) {
            alert("Usuário Logado!");
            $location.path('/Home');
        },
        function (err) {
            $scope.message = err.error_description;
        });
    };
}]);
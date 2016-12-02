angular.module('Diamond').controller('LoginCtrl', function ($scope, HomeService, UtilService, $cookies) {
    $scope.email = "";
    $scope.senha = "";

    $scope.logar = function () {

    };
})
.service('loginService', function ($htpp) {
    return {
        logar: function (params) {
            return $http({
                method: 'POST',
                url: '',
                data: params
            })
        }
    }
});
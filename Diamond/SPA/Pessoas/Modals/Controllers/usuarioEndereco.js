angular.module('Diamond').controller('UsuarioEnderecoCtrl', function ($scope, $uibModalInstance) {
    $scope.fechar = function () {
        $uibModalInstance.dismiss('cancel');
    };
})
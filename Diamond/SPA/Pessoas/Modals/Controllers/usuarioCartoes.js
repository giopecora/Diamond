angular.module('Diamond').controller('UsuarioCartoesCtrl', function ($scope, $uibModalInstance) {
    $scope.fechar = function () {
        $uibModalInstance.dismiss('cancel');
    };
})
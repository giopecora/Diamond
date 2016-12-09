angular.module('Diamond').controller('UsuarioSenhaCtrl', function ($scope, $uibModalInstance) {
    $scope.fechar = function () {
        $uibModalInstance.dismiss('cancel');
    };

    $scope.salvar = function (senhas) {

    }
});
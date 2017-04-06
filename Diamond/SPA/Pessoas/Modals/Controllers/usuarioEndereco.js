angular.module('Diamond').controller('UsuarioEnderecoCtrl', function ($scope, $uibModalInstance, getUsuario, UsuarioEnderecoService) {

    $scope.usuario = getUsuario;
    $scope.enderecos = [];
    $scope.formEndereco = {
        logradouro: '',
        numero: '',
        complemento: '',
        cep: '',
        cidade: '',
        bairro: '',
        uf: '',
        sigla: ''
    }
    $scope.novoEndereco = false;

    $scope.fechar = function () {
        $uibModalInstance.dismiss('cancel');
    };

    $scope.load = function () {
        UsuarioEnderecoService.listarEnderecos().then(function (retorno) {
            $scope.enderecos = retorno.data
        })
    };


    $scope.consultaCEP = function (cep) {
        if ((cep && cep.length < 8) || !cep)
            return;

        UsuarioEnderecoService.consultaCEP(cep).
          then(function (retorno) {
              $scope.formEndereco = retorno.data;
              $scope.formEndereco.cidade = retorno.data.localidade;
          }).catch(function (retorno) {
              if(retorno)
                return;
          });
    };

    $scope.removerEndereco = function (enderecoID) {
        if (window.confirm("Deseja Excluir o endereço?")) {
            UsuarioEnderecoService.excluirEndereco(enderecoID).then(function (retorno) {
                var index = $scope.enderecos.findIndex(function (endereco) {
                    return endereco.id = retorno.data.id;
                });

                $scope.enderecos.splice(index, 1);
            })
        }
    };

    $scope.abrirAdicionarEndereco = function () {
        $scope.novoEndereco = true;
    }

    $scope.salvarNovoEndereco = function () {
        var tmpEndereco = JSON.stringify($scope.formEndereco);

        UsuarioEnderecoService.salvarNovoEndereco(tmpEndereco).then(function (retorno) {

            var enderecoCadastrado = retorno.data
            $scope.enderecos.splice(0, 0, enderecoCadastrado);
            alert("Novo endereço cadastrado com sucesso!");


            //limpa os campos
            Object.keys($scope.usuario).forEach(function (prop) {
                $scope.usuario[prop] = '';
            });

            $scope.novoEndereco = false;
        })

    };

    $scope.load();
})
.service('UsuarioEnderecoService', function ($http, authService) {
    return {
        listarEnderecos: function () {
            return $http({
                method: 'GET',
                url: UtilService.montarUrl('Endereco/GetAllFromUser')
            })
        },
        excluirEndereco: function (enderecoID) {
            return $http({
                method: 'DELETE',
                url: UtilService.montarUrl('Endereco/Delete/' + enderecoID)
            })
        },
        salvarNovoEndereco: function (novoEndereco) {
            return $http({
                method: 'POST',
                url: UtilService.montarUrl('Endereco/Post'),
                data: novoEndereco
            })
        },
        consultaCEP: function (cep) {
            return $http({
                method: 'GET',
                url: 'http://viacep.com.br/ws/' + cep + '/json/'
                
            })
        }
    }
});
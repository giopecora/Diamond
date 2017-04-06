angular.module('Diamond').controller('PessoasCadastro', function ($scope, ProdutoCategoriaService, $routeParams, $location, UsuarioService) {
    
    $scope.usuario = {
        login: '',        
        senha: '',
        nome: '',
        cpf: ''
    }
    $scope.endereco = {
        logradouro: '',
        numero: '',        
        complemento: '',
        cep: '',
        cidade: '',
        bairro: '',
        uf: ''
    }
    

    $scope.validaUsuario = function () {

        var tmpUsuario = JSON.stringify($scope.usuario);

        UsuarioService.cadastrarUsuario(tmpUsuario)
        .then(function (retorno) {
            Object.keys($scope.usuario).forEach(function (prop) {
                //limpa o objeto de usuário
                $scope.usuario[prop] = '';
            });
            console.log(retorno.data.id);
            $location.path("Usuarios/" + retorno.data.id);
        })

        .catch(function (error) {
            window.alert("Não foi possível cadastrar usuário, tente novamente!")
        });

    }

    $scope.consultaCEP = function (cep) {
        if ((cep && cep.length < 8) || !cep)
            return;

        UsuarioService.consultaCEP(cep).
          then(function (retorno) {
              $scope.formEndereco = retorno.data;
              $scope.formEndereco.cidade = retorno.data.localidade;
          }).catch(function (retorno) {
              if (retorno)
                  return;
          });
    };

    $scope.validaEndereco = function () {
        var tmpEndereco = JSON.stringify($scope.endereco);

        UsuarioService.cadastrarEndereco(tmpEndereco).then(function () {
            Object.keys($scope.endereco).forEach(function (prop) {
                $scope.endereco[prop] = '';
            });

            //redirecionar o cara para home ou para o carrinho? e.e
            $location.path = '';

            //NÃO ESQUECER DE MOSTRAR MSG DE SUCESSO!
        }).catch(function (error) {
            //msg de erro
            
        })
    }

})
.service('UsuarioService', function ($http) {
    return {
        cadastrarUsuario: function (usuario) {
            return $http({
                method: 'POST',
                url: 'http://localhost:59783/api/Usuario/Post',
                data: usuario
            });
        },
        cadastrarEndereco: function(endereco){
            return $http({
                method: 'POST',
                url: '',
                data: endereco
            })
        },
        cadastraCartao: function (cartao) {
            return $http({
                method: 'POST',
                url: '',
                data: cartao
            })
        },
        consultaCEP: function (cep) {
            return $http({
                method: 'GET',
                url: 'http://viacep.com.br/ws/' + cep + '/json/'
            });
        }
    }
});
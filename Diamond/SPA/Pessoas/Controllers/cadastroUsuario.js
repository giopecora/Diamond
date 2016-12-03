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
        UF: ''
    }
    $scope.passo = 1;
    
    $scope.consultaCEP = function (cep) {
        if (cep.length < 8)
            return;

        parceirosService.consultaCEP(cep).
          then(function (retorno) {
              $scope.endereco = retorno.data;
          }).catch(function () {
              alert(retorno.message || "Houve um erro desconhecido");
              return;
          });
    };

    $scope.validaUsuario = function () {

        var tmpUsuario = JSON.stringify($scope.usuario);
        UsuarioService.cadastrarUsuario(tmpUsuario).then(function (retorno) {
            Object.keys($scope.usuario).forEach(function (prop) {
                $scope.usuario[prop] = '';
            });
            $scope.passo = 2;
        }).catch(function (error) {
            console.log();
        });

    }

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



    //////////////////////////////////////////////////////////////////////////// MASCARAS INPUT  -- //////////////////////////////

    


    ////////////////////////////////////////////////////////////////////////////  END MASCARAS INPUT  --/////////////////////////////

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
        }
    }
});
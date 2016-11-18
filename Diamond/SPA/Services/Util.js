angular.module('Diamond').service('UtilService', function ($http, $cookies) {

    return {
        adicionarAoCarrinho: function (produto) {
            var TmpCarrinho = [];
            if ($cookies.Carrinho) {
                TmpCarrinho = JSON.parse($cookies.Carrinho);

                if (Array.isArray(TmpCarrinho)) {
                    TmpCarrinho.push(produto);
                }

                $cookies.Carrinho = JSON.stringify(TmpCarrinho);
            } else {
                TmpCarrinho.push(produto);
                $cookies.Carrinho = JSON.stringify(TmpCarrinho);
            }
        }
    };
});
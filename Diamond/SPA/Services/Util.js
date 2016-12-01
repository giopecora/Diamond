﻿angular.module('Diamond').service('UtilService', function ($http, $cookies, $location) {

    return {
        adicionarAoCarrinho: function (produto) {
            var TmpCarrinho = [];
            var TmpProduto = 
                {
                    action: produto.action,
                    categoriaId: produto.categoriaId,
                    id: produto.id,
                    imagemPrincipal: produto.imagemPrincipal,
                    nome: produto.nome,
                    quantidade: produto.quantidade, 
                    preco: produto.preco,
                    totalUnitario: eval("produto.quantidade * produto.preco")
                };
            if ($cookies.get('Produtos')) {
                TmpCarrinho = JSON.parse($cookies.get('Produtos'));

                var indexProdutoCarrinho = TmpCarrinho.findIndex(function (itemCarrinho) { return TmpProduto.id == itemCarrinho.id });

                if (indexProdutoCarrinho != -1) {
                    TmpProduto.quantidade++;
                    TmpProduto.totalUnitario = eval("TmpProduto.quantidade * produto.preco")
                    TmpCarrinho.splice(indexProdutoCarrinho, 1, TmpProduto);
                }
                else {
                    TmpCarrinho.push(TmpProduto);
                }

                $cookies.put('Produtos', JSON.stringify(TmpCarrinho));
            } else {
                TmpCarrinho.push(TmpProduto);
                $cookies.put('Produtos', JSON.stringify(TmpCarrinho));
            }

            $location.path('/CarrinhoCompra');
            
        },
        removerDoCarrinho: function (produto) {
            var TmpCarrinho = JSON.parse($cookies.get('Produtos'));

            var index = TmpCarrinho.findIndex(function (itemCarrinho) { return produto.id == itemCarrinho.id });
            if (index != -1) {
                TmpCarrinho.splice(index, 1);
                $cookies.put('Produtos', TmpCarrinho);
            }

        },

        atualizarQuantidade: function (produto) {
            var TmpProdutos = JSON.parse($cookies.get('Produtos'));

            var index = TmpCarrinho.findIndex(function (itemCarrinho) { return produto.id == itemCarrinho.id });

            if (index != -1) {
                TmpProdutos[index].quantidade = produto.quantidade;
                $cookies.put('Produtos', TmpCarrinho);
            }

        },

        obterProdutos: function () {
            return JSON.parse($cookies.get('Produtos'));
        },
        limparCarrinho: function () {
            $cookies.remove('Produtos');
        }

    };
}).filter('truncate', function () {
    return function (text) {
        if (text) {
            if (text.length > 73) {
                return String(text).substring(0, 70) + "...";
            } else {
                return text;
            }
        }
    };
})
.filter('truncateHome', function () {
    return function (text) {
        if (text) {
            if (text.length > 18) {
                return String(text).substring(0, 18) + "...";
            } else {
                return text;
            }
        }
    };
});
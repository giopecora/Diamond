angular.module('Diamond').service('UtilService', function ($http, $cookies) {

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
                    quantidade: produto.quantidade
                };
            if ($cookies.get('Produtos')) {
                TmpCarrinho = JSON.parse($cookies.get('Produtos'));

                var indexProdutoCarrinho = TmpCarrinho.findIndex(function (itemCarrinho) { return TmpProduto.id == itemCarrinho.id });

                if (indexProdutoCarrinho != -1) {
                    TmpProduto.quantidade++;
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

        }

    };
});
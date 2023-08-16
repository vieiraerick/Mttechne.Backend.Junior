﻿using Mttechne.Backend.Junior.Services.Model;

namespace Mttechne.Backend.Junior.Services.Services;

public interface IProdutoService
{
    List<Produto> GetListaProdutos();
    List<Produto> GetListaProdutosPorNome(string nome);
    List<Produto> GetListaProdutosOrdenadosPorValor(bool crescente);
    List<Produto> GetListaProdutosEntreFaixaValor(int maximo, int minimo);
    List<Produto?> GetListaValoresMaximosCadaProduto();
    List<Produto?> GetListaValoresMinimosCadaProduto();
}
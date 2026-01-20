namespace ProjectPP.Services.Interfaces;

public interface IProdutoService
{
    Task AdicionarProdutoAgregado(AdicionarProdutoServiceDto adicionarAtributoProdutoDto);
    Task AtualizarProdutoAgregado(AtualizarProdutoServiceDto atualizarProdutoServiceDto);
}

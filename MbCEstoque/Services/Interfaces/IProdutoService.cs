public interface IProdutoService
{
    Task<List<Produto>> ListarTodasAsProduto();
    Task<Produto?> PesquisarProdutoPorId(int id);
    Task<Produto> CriarAsync(Produto Produto);
    Task<Produto?> AlterarAsync(Produto Produto);
    Task<bool> ExcluirAsync(int id);
}
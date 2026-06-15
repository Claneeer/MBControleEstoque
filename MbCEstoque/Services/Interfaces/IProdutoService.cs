namespace MbCEstoque.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<List<Produto>>  ListarTodosProduto();
        Task<Produto?>       PesquisarProdutoPorId(int id);
        Task                 CriarAsync(Produto produto);
        Task<bool>           AlterarAsync(Produto produto);
        Task<bool>           ExcluirAsync(int id);
    }
}
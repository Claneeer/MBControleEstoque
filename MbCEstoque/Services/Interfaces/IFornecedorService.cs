namespace MbCEstoque.Services.Interfaces
{
    public interface IFornecedorService
    {
        Task<List<Fornecedor>> ListarTodasFornecedor();
        Task<Fornecedor?> PesquisarFornecedorPorId(int id);
        Task<Fornecedor> CriarAsync(Fornecedor fornecedor);
        Task<bool> AlterarAsync(Fornecedor fornecedor);
        Task<bool> ExcluirAsync(int id);
    }
}

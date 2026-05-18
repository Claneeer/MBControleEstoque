namespace MbCEstoque.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task<List<Categoria>> ListarTodasAsCategorias();
            Task<Categoria?> PesquisarCategoriaPorId(int id);
            Task<Categoria> CriarAsync(Categoria categoria);
            Task<Categoria?> AlterarAsync(Categoria categoria);
            Task<bool> ExcluirAsync(int id);
    }
}

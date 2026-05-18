public interface IProdutoService
{
    Task<List<Produto>> GetAllAsync(bool apenasAtivos = true);
    Task<Produto?> GetByIdAsync(int id);
    Task<Produto> CreateAsync(Produto produto);
    Task<Produto> UpdateAsync(Produto produto);
    Task<bool> DeleteAsync(int id);          // soft delete
    Task<List<Produto>> GetEstoqueBaixoAsync();
    Task<List<Produto>> SearchAsync(string termo);
}
using Microsoft.EntityFrameworkCore;

public class ProdutoService : IProdutoService
{
    public Task<Produto?> AlterarAsync(Produto Produto)
    {
        throw new NotImplementedException();
    }

    public Task<Produto> CriarAsync(Produto Produto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExcluirAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Produto>> ListarTodasAsProduto()
    {
        throw new NotImplementedException();
    }

    public Task<Produto?> PesquisarProdutoPorId(int id)
    {
        throw new NotImplementedException();
    }
}
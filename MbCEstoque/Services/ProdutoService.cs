using Microsoft.EntityFrameworkCore;

public class ProdutoService : IProdutoService
{
    private readonly IDbContextFactory<EstoqueDbContext> _factory;

    public ProdutoService(IDbContextFactory<EstoqueDbContext> factory)
        => _factory = factory;

    public async Task<List<Produto>> GetAllAsync(bool apenasAtivos = true)
    {
        // "await using" garante que o ctx é descartado mesmo em exceções
        await using var ctx = await _factory.CreateDbContextAsync();
        return await ctx.Produtos
            .Include(p => p.Categoria)
            .Include(p => p.Fornecedor)
            .Include(p => p.Estoque)
            .Where(p => !apenasAtivos || p.Ativo)
            .OrderBy(p => p.Nome)
            .ToListAsync();
    }

    public async Task<Produto> CreateAsync(Produto produto)
    {
        await using var ctx = await _factory.CreateDbContextAsync();
        produto.DataCadastro = DateTime.Now;
        ctx.Produtos.Add(produto);
        // Cria o registro de estoque zerado junto com o produto
        ctx.Estoques.Add(new Estoque { Produto = produto });
        await ctx.SaveChangesAsync();
        return produto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        await using var ctx = await _factory.CreateDbContextAsync();
        var p = await ctx.Produtos.FindAsync(id);
        if (p is null) return false;
        p.Ativo = false;    // Soft delete — mantém histórico de movimentações
        await ctx.SaveChangesAsync();
        return true;
    }

    public async Task<List<Produto>> GetEstoqueBaixoAsync()
    {
        await using var ctx = await _factory.CreateDbContextAsync();
        return await ctx.Produtos
            .Include(p => p.Estoque)
            .Where(p => p.Ativo
                && p.Estoque != null
                && p.Estoque.QuantidadeAtual < p.Estoque.EstoqueMinimo)
            .ToListAsync();
    }
}
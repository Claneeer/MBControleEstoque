using MbCEstoque.Services.Interfaces;
using MBCEstoque.Data;
using Microsoft.EntityFrameworkCore;

namespace MbCEstoque.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly SQLServerEstoqueDbContext _context;

        public ProdutoService(SQLServerEstoqueDbContext context)
        {
            _context = context;
        }

        public async Task<List<Produto>> ListarTodosProduto()
        {
            return await _context.Produtos.AsNoTracking().ToListAsync();
        }

        public async Task<Produto?> PesquisarProdutoPorId(int id)
        {
            return await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CriarAsync(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AlterarAsync(Produto produto)
        {
            var existe = await _context.Produtos.AnyAsync(p => p.Id == produto.Id);
            if (!existe) return false;

            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto is null) return false;

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
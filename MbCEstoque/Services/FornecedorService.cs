using MbCEstoque.Services.Interfaces;
using MBCEstoque.Data;
using Microsoft.EntityFrameworkCore;

namespace MbCEstoque.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly SQLServerEstoqueDbContext _context;

        public FornecedorService(SQLServerEstoqueDbContext context)
        {
            _context = context;
        }

        public async Task<List<Fornecedor>> ListarTodasFornecedor()
        {
            return await _context.Fornecedores.AsNoTracking().ToListAsync();
        }

        public async Task<Fornecedor?> PesquisarFornecedorPorId(int id)
        {
            return await _context.Fornecedores.AsNoTracking().FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Fornecedor> CriarAsync(Fornecedor fornecedor)
        {
            _context.Fornecedores.Add(fornecedor);
            await _context.SaveChangesAsync();
            return fornecedor;
        }

        public async Task<bool> AlterarAsync(Fornecedor fornecedor)
        {
            var existe = await _context.Fornecedores.AnyAsync(f => f.Id == fornecedor.Id);
            if (!existe) return false;

            _context.Fornecedores.Update(fornecedor);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor is null) return false;

            _context.Fornecedores.Remove(fornecedor);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

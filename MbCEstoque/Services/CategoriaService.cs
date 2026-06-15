using MbCEstoque.Services.Interfaces;
using MBCEstoque.Data;
using Microsoft.EntityFrameworkCore;

namespace MbCEstoque.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly SQLServerEstoqueDbContext _context;

        public CategoriaService(SQLServerEstoqueDbContext context)
        {
            _context = context;
        }

        public async Task<List<Categoria>> ListarTodasAsCategorias()
        {
            return await _context.Categorias.AsNoTracking().ToListAsync();
        }

        public async Task<Categoria?> PesquisarCategoriaPorId(int id)
        {
            return await _context.Categorias.AsNoTracking().FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Categoria> CriarAsync(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<bool?> AlterarAsync(Categoria categoria)
        {
            var existe = await _context.Categorias.AnyAsync(f => f.Id == categoria.Id);
            if (!existe) return null;

            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria is null) return false;

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

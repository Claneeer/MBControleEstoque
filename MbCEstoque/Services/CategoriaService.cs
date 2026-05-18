using MbCEstoque.Services.Interfaces;

namespace MbCEstoque.Services
{
    public class CategoriaService : ICategoriaService
    {
        public Task<Categoria?> AlterarAsync(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Task<Categoria> CriarAsync(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExcluirAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Categoria>> ListarTodasAsCategorias()
        {
            throw new NotImplementedException();
        }

        public Task<Categoria?> PesquisarCategoriaPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}

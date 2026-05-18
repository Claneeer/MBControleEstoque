using MbCEstoque.Services.Interfaces;

namespace MbCEstoque.Services
{
    public class FornecedorService : IFornecedorService
    {
        public Task<Fornecedor?> AlterarAsync(Fornecedor fornecedor)
        {
            throw new NotImplementedException();
        }

        public Task<Fornecedor> CriarAsync(Fornecedor fornecedor)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExcluirAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Fornecedor>> ListarTodasFornecedor()
        {
            throw new NotImplementedException();
        }

        public Task<Fornecedor?> PesquisarFornecedorPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}

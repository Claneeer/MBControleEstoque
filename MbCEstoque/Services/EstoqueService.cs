using MbCEstoque.Services.Interfaces;

namespace MbCEstoque.Services
{
    public class EstoqueService : IEstoqueService
    {
        public Task<MovimentacaoEstoque> RegistrarEntradaAsync(int pordutoId, int qualidade, string? obs = null)
        {
            throw new NotImplementedException();
        }

        public Task<MovimentacaoEstoque> RegistrarSaidaAsync(int pordutoId, int qualidade, string? obs = null)
        {
            throw new NotImplementedException();
        }
    }
}

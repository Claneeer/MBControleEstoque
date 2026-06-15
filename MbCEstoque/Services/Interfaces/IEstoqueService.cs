using MbCEstoque.Models;

namespace MbCEstoque.Services.Interfaces
{
    public interface IEstoqueService
    {
        Task<MovimentacaoEstoque> RegistrarEntradaAsync(
            int produtoId, int quantidade, string? obs = null);
        Task<MovimentacaoEstoque> RegistrarSaidaAsync(
            int produtoId, int quantidade, string? obs = null);
    }
}

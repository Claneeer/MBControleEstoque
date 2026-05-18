using MbCEstoque.Models;
namespace MbCEstoque.Services.Interfaces
{
    public interface IEstoqueService
    {
        Task<MovimentacaoEstoque> RegistrarEntradaAsync(
            int pordutoId, int qualidade, string? obs=null);
        Task<MovimentacaoEstoque> RegistrarSaidaAsync(
            int pordutoId, int qualidade, string? obs=null);
    }
}

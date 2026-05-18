using MbCEstoque.Models;
namespace MbCEstoque.Services.Interfaces
{
    public interface IEstoqueService
    {
        Task<MovimentacaoEstoque> RegistrarMovimentacaoAsync(
            int pordutoId, int qualidade, string? obs=null);
    }
}

using MbCEstoque.Models;
using MbCEstoque.Services.Interfaces;
using MBCEstoque.Data;
using Microsoft.EntityFrameworkCore;

namespace MbCEstoque.Services
{
    public class EstoqueService : IEstoqueService
    {
        private readonly SQLServerEstoqueDbContext _context;

        public EstoqueService(SQLServerEstoqueDbContext context)
        {
            _context = context;
        }

        public async Task<MovimentacaoEstoque> RegistrarEntradaAsync(int produtoId, int quantidade, string? obs = null)
        {
            if (quantidade <= 0)
                throw new ArgumentException("A quantidade de entrada deve ser maior que zero.", nameof(quantidade));

            // Busca o registro de estoque do produto
            var estoque = await _context.Estoques
                .FirstOrDefaultAsync(e => e.ProdutoId == produtoId)
                ?? throw new InvalidOperationException($"Estoque não encontrado para o produto com Id {produtoId}.");

            var quantidadeAnterior = estoque.QuantidadeAtual;
            estoque.QuantidadeAtual += quantidade;
            estoque.UltimaAtualizacao = DateTime.UtcNow;

            var movimentacao = new MovimentacaoEstoque
            {
                ProdutoId      = produtoId,
                TipoMovimentacao = TipoMovimentacao.Entrada,
                Quantidade       = quantidade,
                QuantidadeAnterior = quantidadeAnterior,
                QuantidadeAtual    = estoque.QuantidadeAtual,
                Observacao       = obs,
                DataMovimentacao = DateTime.UtcNow
            };

            _context.Movimentacoes.Add(movimentacao);
            await _context.SaveChangesAsync();

            return movimentacao;
        }

        public async Task<MovimentacaoEstoque> RegistrarSaidaAsync(int produtoId, int quantidade, string? obs = null)
        {
            if (quantidade <= 0)
                throw new ArgumentException("A quantidade de saída deve ser maior que zero.", nameof(quantidade));

            var estoque = await _context.Estoques
                .FirstOrDefaultAsync(e => e.ProdutoId == produtoId)
                ?? throw new InvalidOperationException($"Estoque não encontrado para o produto com Id {produtoId}.");

            if (estoque.QuantidadeAtual < quantidade)
                throw new InvalidOperationException(
                    $"Estoque insuficiente. Disponível: {estoque.QuantidadeAtual}, solicitado: {quantidade}.");

            var quantidadeAnterior = estoque.QuantidadeAtual;
            estoque.QuantidadeAtual -= quantidade;
            estoque.UltimaAtualizacao = DateTime.UtcNow;

            var movimentacao = new MovimentacaoEstoque
            {
                ProdutoId        = produtoId,
                TipoMovimentacao = TipoMovimentacao.Saida,
                Quantidade       = quantidade,
                QuantidadeAnterior = quantidadeAnterior,
                QuantidadeAtual    = estoque.QuantidadeAtual,
                Observacao       = obs,
                DataMovimentacao = DateTime.UtcNow
            };

            _context.Movimentacoes.Add(movimentacao);
            await _context.SaveChangesAsync();

            return movimentacao;
        }
    }
}

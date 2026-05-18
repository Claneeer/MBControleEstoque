using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Enum mapeado para TINYINT no banco (byte = 1 ou 2)
// Evita "magic numbers" — melhora legibilidade
public enum TipoMovimentacao
{
    Entrada = 1,    // Recebimento de mercadoria
    Saida = 2     // Venda, consumo, descarte
}

public class MovimentacaoEstoque
{
    [Key]
    public int Id { get; set; }

    // FK — o produto ao qual a movimentação pertence
    public int ProdutoId { get; set; }
    [ForeignKey(nameof(ProdutoId))]
    public virtual Produto? Produto { get; set; }

    // EF Core converte o Enum para byte ao gravar, e byte para Enum ao ler
    public TipoMovimentacao TipoMovimentacao { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Quantidade deve ser >= 1")]
    public int Quantidade { get; set; }
    public int QuantidadeAnterior { get; set; }   // snapshot pré-operação
    public int QuantidadeAtual { get; set; }   // snapshot pós-operação

    [MaxLength(500)]
    public string? Observacao { get; set; }
    public DateTime DataMovimentacao { get; set; } = DateTime.Now;

    // Propriedade calculada para exibição na UI
    [NotMapped]
    public string TipoLabel => TipoMovimentacao == TipoMovimentacao.Entrada
        ? "📥 Entrada" : "📤 Saída";
}
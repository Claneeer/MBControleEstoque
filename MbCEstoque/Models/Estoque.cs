using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Estoque
{
    [Key]
    public int Id { get; set; }

    // FK para Produto — junto com UNIQUE INDEX garante o 1:1
    // O UNIQUE INDEX é configurado no DbContext via Fluent API
    public int ProdutoId { get; set; }
    [ForeignKey(nameof(ProdutoId))]
    public virtual Produto? Produto { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Quantidade não pode ser negativa")]
    public int QuantidadeAtual { get; set; }

    public int EstoqueMinimo { get; set; }
    public int EstoqueMaximo { get; set; } = 9999;

    [MaxLength(100)]
    public string? Localizacao { get; set; }   // ex: "Prateleira A-12"

    public DateTime UltimaAtualizacao { get; set; } = DateTime.Now;

    // [NotMapped] = propriedade calculada — NÃO cria coluna no banco
    // Acessível via C#, ignorada pelo EF Core no SQL
    [NotMapped]
    public bool EstaBaixo => QuantidadeAtual < EstoqueMinimo;

    [NotMapped]
    public string Status =>
        QuantidadeAtual == 0 ? "Sem Estoque" :
        QuantidadeAtual < EstoqueMinimo ? "Crítico" :
        QuantidadeAtual >= EstoqueMaximo ? "Cheio" : "Normal";
}
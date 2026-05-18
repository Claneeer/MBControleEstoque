using MbCEstoque.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Produto
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nome { get; set; } = "";

    [MaxLength(500)]
    public string? Descricao { get; set; }

    [MaxLength(50)]
    public string? CodigoBarras { get; set; }

    // Column configura o tipo SQL exato (decimal monetário)
    [Column(TypeName = "decimal(18,2)")]
    [Range(0, 999999, ErrorMessage = "Preço deve ser positivo")]
    public decimal PrecoUnitario { get; set; }

    // ── RELACIONAMENTO N:1 com Categoria ──────────────────────
    // CategoriaId é a coluna FK na tabela Produtos
    // Categoria é a navigation property (não gera coluna)
    public int CategoriaId { get; set; }
    [ForeignKey(nameof(CategoriaId))]
    public virtual Categoria? Categoria { get; set; }

    // ── RELACIONAMENTO N:1 com Fornecedor ─────────────────────
    public int FornecedorId { get; set; }
    [ForeignKey(nameof(FornecedorId))]
    public virtual Fornecedor? Fornecedor { get; set; }

    public bool Ativo { get; set; } = true;
    public DateTime DataCadastro { get; set; } = DateTime.Now;

    // ── RELACIONAMENTO 1:1 com Estoque ────────────────────────
    // Navegação inversa — o EF Core mapeia pelo FK em Estoque.ProdutoId
    public virtual Estoque? Estoque { get; set; }

    // ── RELACIONAMENTO 1:N com MovimentacaoEstoque ────────────
    public virtual ICollection<MovimentacaoEstoque> Movimentacoes { get; set; } = [];
}
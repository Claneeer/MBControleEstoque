using MbCEstoque.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Fornecedor
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string RazaoSocial { get; set; } = "";

    [Required]
    [MaxLength(18)]
    public string CNPJ { get; set; } = "";      // "XX.XXX.XXX/XXXX-XX"

    [MaxLength(200)]
    [EmailAddress]
    public string? Email { get; set; }

    [MaxLength(20)]
    [Phone]
    public string? Telefone { get; set; }

    [MaxLength(300)]
    public string? Endereco { get; set; }

    public bool Ativo { get; set; } = true;

    // Navigation: um fornecedor pode ter muitos produtos
    public virtual ICollection<Produto> Produtos { get; set; } = [];
}
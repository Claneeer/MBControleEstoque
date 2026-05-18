using MbCEstoque.Models;
using System.ComponentModel.DataAnnotations;

public class Categoria
{
    [Key]                            
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome é obrigatório")]
    [MaxLength(100, ErrorMessage = "Esse campo pode ter no máximo 100 caracteres")]
    public string Nome { get; set; } = "";

    [MaxLength(500)]
    public string? Descricao { get; set; }  

    public bool Ativo { get; set; } = true; 
    public virtual ICollection<Produto> Produtos { get; set; } = [];
}
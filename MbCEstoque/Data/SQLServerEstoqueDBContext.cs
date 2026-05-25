using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Identity.Client;

namespace MBCEstoque.Data
{
    public class SQLServerEstoqueDbContext : DbContext
    {
        public SQLServerEstoqueDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<MovimentacaoEstoque> Movimentacoes { get; set; }

        // ── OnModelCreating ──────────────────────────────────────────
        // Configurações avançadas que não podem ser feitas via Data Annotations.
        // Aqui usamos a Fluent API — alternativa mais poderosa às annotations.
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // ── Nomes explícitos das tabelas ─────────────────────────
            builder.Entity<Produto>().ToTable("Produto");
            builder.Entity<Categoria>().ToTable("Categoria");
            builder.Entity<Fornecedor>().ToTable("Fornecedore");
            builder.Entity<Estoque>().ToTable("Estoque");
            builder.Entity<MovimentacaoEstoque>().ToTable("MovimentacoesEstoque");

            // ── Relacionamento 1:1 Produto → Estoque ─────────────────
            // HasOne + WithOne define o tipo do relacionamento
            // OnDelete Cascade: ao deletar produto, o estoque é deletado junto
            builder.Entity<Produto>()
                .HasOne(p => p.Estoque)
                .WithOne(e => e.Produto)
                .HasForeignKey<Estoque>(e => e.ProdutoId)
                .OnDelete(DeleteBehavior.Cascade);

            // UNIQUE INDEX em ProdutoId garante a cardinalidade 1:1
            builder.Entity<Estoque>()
                .HasIndex(e => e.ProdutoId).IsUnique();

            // ── Enum → byte no banco ─────────────────────────────────
            // TipoMovimentacao é armazenado como TINYINT (1 ou 2)
            // O EF Core converte automaticamente entre Enum e byte
            builder.Entity<MovimentacaoEstoque>()
                .Property(m => m.TipoMovimentacao)
                .HasConversion<byte>();

            // ── Índices para performance ─────────────────────────────
            builder.Entity<Produto>().HasIndex(p => p.Nome);
            builder.Entity<Produto>().HasIndex(p => p.CodigoBarras).IsUnique();
            builder.Entity<MovimentacaoEstoque>().HasIndex(m => m.DataMovimentacao);

            // ── Seed data — categorias padrão ────────────────────────
            builder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nome = "Eletrônicos", Ativo = true },
                new Categoria { Id = 2, Nome = "Informática", Ativo = true },
                new Categoria { Id = 3, Nome = "Escritório", Ativo = true }
            );
        }
    }
}


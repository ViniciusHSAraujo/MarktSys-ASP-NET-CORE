using MarktSys_ASP_NET_CORE.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MarktSys_ASP_NET_CORE.DTO;

namespace MarktSys_ASP_NET_CORE.Data {
    public class ApplicationDbContext : IdentityDbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Fornecedor> Fornecedores { get; set; }

        public DbSet<Unidade> Unidades { get; set; }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Promocao> Promocoes { get; set; }
        public DbSet<PromocaoProduto> PromocoesProdutos { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<Saida> Saidas { get; set; }
        public DbSet<Venda> Vendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PromocaoProduto>()
                .HasKey(table => new { table.PromocaoId, table.ProdutoId });

            modelBuilder.Entity<PromocaoProduto>()
            .HasOne(pp => pp.Promocao)
            .WithMany(p => p.PromocaoProdutos)
            .HasForeignKey(pt => pt.PromocaoId);

            modelBuilder.Entity<PromocaoProduto>()
                .HasOne(pt => pt.Produto)
                .WithMany(t => t.PromocaoProdutos)
                .HasForeignKey(pt => pt.ProdutoId);
        }
    }
}

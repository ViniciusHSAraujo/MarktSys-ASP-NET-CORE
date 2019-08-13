using System;
using System.Collections.Generic;
using System.Text;
using MarktSys_ASP_NET_CORE.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MarktSys_ASP_NET_CORE.Data
{
    public class ApplicationDbContext : IdentityDbContext{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }

        public DbSet<Fornecedor> Fornecedores { get; set; }

        public DbSet<Unidade> Unidades { get; set; }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Promocao> Promocoes { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<Saida> Saidas { get; set; }
        public DbSet<Venda> Vendas { get; set; }

    }
}

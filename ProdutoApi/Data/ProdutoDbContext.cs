using Microsoft.EntityFrameworkCore;
using ProdutoApi.Models;
using System.Collections.Generic;

namespace ProdutoApi.Data
{
    public class ProdutoDbContext : DbContext
    {
        public ProdutoDbContext(DbContextOptions<ProdutoDbContext> options) : base(options) { }
        public DbSet<Produto> Produtos { get; set; }
    }
}

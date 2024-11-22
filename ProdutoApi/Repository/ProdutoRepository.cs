using Microsoft.EntityFrameworkCore;
using ProdutoApi.Data;
using ProdutoApi.Models;

namespace ProdutoApi.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ProdutoDbContext _context;

        public ProdutoRepository(ProdutoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> GetAllAsync() => await _context.Produtos.ToListAsync();

        public async Task<Produto?> GetByIdAsync(int id) => await _context.Produtos.FindAsync(id);

        public async Task AddAsync(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
            }
        }
    }
}

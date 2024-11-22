using InterfaceMvc.Models;

namespace InterfaceMvc.Services
{
    public interface IProdutoService
    {
        Task<List<Produto>> GetProdutosAsync();
        Task<Produto> GetProdutoByIdAsync(int id);
        Task CreateProdutoAsync(Produto produto);
        Task UpdateProdutoAsync(Produto produto);
        Task DeleteProdutoAsync(int id);
    }

    public class ProdutoService : IProdutoService
    {
        private readonly HttpClient _httpClient;

        public ProdutoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Produto>> GetProdutosAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7132/api/produtos");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<List<Produto>>();
        }

        public async Task<Produto> GetProdutoByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7132/api/produtos/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<Produto>();
        }

        public async Task CreateProdutoAsync(Produto produto)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7132/api/produtos", produto);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateProdutoAsync(Produto produto)
        {
            var response = await _httpClient.PutAsJsonAsync($"https://localhost:7132/api/produtos/{produto.Id}", produto);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteProdutoAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7132/api/produtos/{id}");
            response.EnsureSuccessStatusCode();
        }
    }

}

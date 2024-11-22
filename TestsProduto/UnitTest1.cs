using Microsoft.AspNetCore.Mvc;
using Moq;
using ProdutoApi.Controller;
using ProdutoApi.Models;
using ProdutoApi.Repository;

namespace TestsProduto
{
    public class ProdutosControllerTests
    {
        private readonly Mock<IProdutoRepository> _mockRepository;
        private readonly ProdutosController _controller;

        public ProdutosControllerTests()
        {
            // Inicializa o Mock do reposit�rio
            _mockRepository = new Mock<IProdutoRepository>();

            // Cria o controlador e injeta o mock do reposit�rio
            _controller = new ProdutosController(_mockRepository.Object);
        }

        [Fact]
        public async Task Get_ReturnsOkResult_WhenProductsExist()
        {
            // Arrange: Simula a resposta do reposit�rio
            var produtos = new List<Produto>
            {
                new Produto { Id = 1, Nome = "Produto 1", Preco = 10 },
                new Produto { Id = 2, Nome = "Produto 2", Preco = 20 }
            };
            _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(produtos);

            // Act: Faz a chamada ao endpoint GET
            var result = await _controller.Get();

            // Assert: Verifica se o resultado � um OkObjectResult com a lista de produtos
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<List<Produto>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public async Task Get_ReturnsNotFoundResult_WhenProductDoesNotExist()
        {
            // Arrange: Simula a resposta do reposit�rio para um produto n�o encontrado
            _mockRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Produto)null);

            // Act: Faz a chamada ao endpoint GET com id 1
            var result = await _controller.Get(1);

            // Assert: Verifica se o resultado � um NotFoundResult
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Post_ReturnsCreatedAtAction_WhenProductIsCreated()
        {
            // Arrange: Cria um novo produto e simula a resposta do reposit�rio
            var produto = new Produto { Id = 3, Nome = "Produto 3", Preco = 30 };
            _mockRepository.Setup(repo => repo.AddAsync(It.IsAny<Produto>())).Returns(Task.CompletedTask);

            // Act: Faz a chamada ao endpoint POST
            var result = await _controller.Post(produto);

            // Assert: Verifica se o resultado � um CreatedAtActionResult
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("Get", createdResult.ActionName);
            Assert.Equal(produto.Id, ((Produto)createdResult.Value).Id);
        }

        [Fact]
        public async Task Put_ReturnsNoContent_WhenProductIsUpdated()
        {
            // Arrange: Cria um produto existente
            var produto = new Produto { Id = 1, Nome = "Produto Atualizado", Preco = 15 };
            _mockRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Produto>())).Returns(Task.CompletedTask);

            // Act: Faz a chamada ao endpoint PUT
            var result = await _controller.Put(1, produto);

            // Assert: Verifica se o resultado � um NoContentResult
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsNoContent_WhenProductIsDeleted()
        {
            // Arrange: Simula a resposta do reposit�rio para deletar um produto
            _mockRepository.Setup(repo => repo.DeleteAsync(It.IsAny<int>())).Returns(Task.CompletedTask);

            // Act: Faz a chamada ao endpoint DELETE
            var result = await _controller.Delete(1);

            // Assert: Verifica se o resultado � um NoContentResult
            Assert.IsType<NoContentResult>(result);
        }
    }
}
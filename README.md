# Produto API

## Descrição do Projeto

Este projeto é uma API RESTful para gerenciamento de produtos. A API permite realizar operações CRUD (Criar, Ler, Atualizar e Deletar) em produtos. A aplicação está estruturada utilizando o framework **ASP.NET Core**, com **Entity Framework** para a manipulação do banco de dados **PostgreSQL**.

## Funcionalidades

- **GET /api/produtos**: Recupera todos os produtos.
- **GET /api/produtos/{id}**: Recupera um produto específico pelo ID.
- **POST /api/produtos**: Cria um novo produto.
- **PUT /api/produtos/{id}**: Atualiza um produto existente.
- **DELETE /api/produtos/{id}**: Deleta um produto pelo ID.

## Tecnologias Utilizadas

- **ASP.NET Core** (Backend)
- **PostgreSQL** (Banco de dados)
- **Entity Framework Core** (ORM)
- **Docker** (Para contêinerização)

## Instruções para Configurar e Executar o Projeto Localmente

### Requisitos

- **.NET SDK** (versão 8)
- **PostgreSQL** 
- **Visual Studio** ou **Visual Studio Code**

### Passos para Configuração

1. **Clone o repositório**:

   ```bash
   git clone https://github.com/GustavoFoss/ProdutoApi.git
   
2. **Instalar dependencias**
   ```bash
   dotnet restore
   
3. **No arquivo appsettings.json, configure a string de conexão com seu banco PostgreSQL:
   ```bash
   "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=produtosdb;Username=seu_usuario;Password=sua_senha"
   }
4. **Crie o banco de dados no seu localhost
   ```bash
   CREATE DATABASE produtosdb;
   
5. **Execute em uma janela do Visual Studio a ProdutoApi como HTTPS
6. **Execute a interface mvc em outra janela do Visual Studio

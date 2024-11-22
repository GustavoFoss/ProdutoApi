# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

# Copiar os arquivos de solução e projetos
COPY ["ProdutoApi/ProdutoApi.csproj", "ProdutoApi/"]
COPY ["InterfaceMvc/InterfaceMvc.csproj", "InterfaceMvc/"]
COPY ["TestsProduto/TestsProduto.csproj", "TestsProduto/"]

# Restaurar pacotes (incluindo FluentMigrator)
RUN dotnet restore "ProdutoApi/ProdutoApi.csproj"

# Copiar todo o código-fonte
COPY . .

# Publicar a aplicação
RUN dotnet publish "ProdutoApi/ProdutoApi.csproj" -c Release -o /app/publish

# Instalar o FluentMigrator na etapa de build
RUN dotnet tool install --global FluentMigrator.DotNet.Cli

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Copiar os arquivos publicados da etapa anterior
COPY --from=build /app/publish .

# Definir o ponto de entrada
ENTRYPOINT ["dotnet", "ProdutoApi.dll"]

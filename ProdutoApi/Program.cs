using FluentMigrator.Runner;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using ProdutoApi.Data;
using ProdutoApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Configuração do Entity Framework Core
builder.Services.AddDbContext<ProdutoDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona serviços do FluentMigrator
builder.Services.AddFluentMigratorCore()
    .ConfigureRunner(runner => runner
        .AddPostgres()
        .WithGlobalConnectionString(builder.Configuration.GetConnectionString("DefaultConnection"))
        .ScanIn(typeof(Program).Assembly).For.Migrations());

// Habilita FluentValidation
builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

var app = builder.Build();

// Executa migrações ao iniciar
using (var scope = app.Services.CreateScope())
{
    var migrator = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
    migrator.MigrateUp();  // Executa todas as migrações pendentes
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

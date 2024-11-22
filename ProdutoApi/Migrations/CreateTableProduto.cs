using FluentMigrator;

namespace ProdutoApi.Migrations
{
    [Migration(20231122)]
    public class CreateTableProduto : Migration
    {
        public override void Up()
        {
            Create.Table("Produtos")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Nome").AsString(100).NotNullable()
                .WithColumn("Descricao").AsString().Nullable()
                .WithColumn("Preco").AsDecimal().NotNullable()
                .WithColumn("DataCadastro").AsDateTime().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Produtos");
        }
    }
}

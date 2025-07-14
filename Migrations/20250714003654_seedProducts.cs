using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogoDeDoces.Migrations
{
    public partial class seedProducts : Migration
    {
        private static readonly string[] columns = new[] { "Nome", "Descricao", "Preco" };

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Produtos",
                columns: columns,
                values: new object[,]
                {
                    { "Brigadeiro", "Doce de chocolate", 3.5 },
                    { "Beijinho", "Doce de coco", 3.0 }
                });
        }
        
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}

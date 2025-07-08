using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogoDeDoces.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsuarioAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "EhAdministrador", "Email", "NomeUsuario", "Senha", "Telefone" },
                values: new object[] { 1, true, "admin@admin.com", "Admin", "wsgVDjEGM2XE7RsaHUnJc98MjliOqPRpvno33IhrmG4of40NGyR1ngYaSzh52CEd", "11999999999" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1);
        }
    }
}

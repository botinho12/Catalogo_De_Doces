using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogoDeDoces.Migrations
{
    /// <inheritdoc />
    public partial class AddCamposTokenParaUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiracaoToken",
                table: "Usuarios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TokenRedefinicaoSenha",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                columns: new[] { "ExpiracaoToken", "Senha", "TokenRedefinicaoSenha" },
                values: new object[] { null, "Q0E433/5OEFlImc8Exv/bwb8hhyllb3zvYcQYm/ZzAMv+LUqujQq8YTD6CldrCKo", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpiracaoToken",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "TokenRedefinicaoSenha",
                table: "Usuarios");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                column: "Senha",
                value: "wsgVDjEGM2XE7RsaHUnJc98MjliOqPRpvno33IhrmG4of40NGyR1ngYaSzh52CEd");
        }
    }
}

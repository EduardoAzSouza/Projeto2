using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projeto2.API.Migrations
{
    public partial class First11Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pessoa",
                keyColumn: "id",
                keyValue: 1L,
                column: "status",
                value: "Ativo");

            migrationBuilder.UpdateData(
                table: "Pessoa",
                keyColumn: "id",
                keyValue: 2L,
                column: "status",
                value: "Ativo");

            migrationBuilder.UpdateData(
                table: "Pessoa",
                keyColumn: "id",
                keyValue: 3L,
                column: "status",
                value: "Ativo");

            migrationBuilder.UpdateData(
                table: "empresa",
                keyColumn: "id",
                keyValue: 1L,
                column: "status",
                value: "Ativo");

            migrationBuilder.UpdateData(
                table: "empresa",
                keyColumn: "id",
                keyValue: 2L,
                column: "status",
                value: "Ativo");

            migrationBuilder.UpdateData(
                table: "empresa",
                keyColumn: "id",
                keyValue: 3L,
                column: "status",
                value: "Ativo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pessoa",
                keyColumn: "id",
                keyValue: 1L,
                column: "status",
                value: "Inativo");

            migrationBuilder.UpdateData(
                table: "Pessoa",
                keyColumn: "id",
                keyValue: 2L,
                column: "status",
                value: "Inativo");

            migrationBuilder.UpdateData(
                table: "Pessoa",
                keyColumn: "id",
                keyValue: 3L,
                column: "status",
                value: "Inativo");

            migrationBuilder.UpdateData(
                table: "empresa",
                keyColumn: "id",
                keyValue: 1L,
                column: "status",
                value: "Inativo");

            migrationBuilder.UpdateData(
                table: "empresa",
                keyColumn: "id",
                keyValue: 2L,
                column: "status",
                value: "Inativo");

            migrationBuilder.UpdateData(
                table: "empresa",
                keyColumn: "id",
                keyValue: 3L,
                column: "status",
                value: "Inativo");
        }
    }
}

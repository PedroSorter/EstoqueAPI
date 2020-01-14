using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstoqueAPI.WebApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Quantidade = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Nome", "Quantidade", "Valor" },
                values: new object[] { new Guid("be1ee539-1f61-45f4-a7bf-97a140a1a29b"), "RTX 2060", 50, 2000.00m });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Nome", "Quantidade", "Valor" },
                values: new object[] { new Guid("62f24c8d-f823-4aff-86a6-57373cf0028d"), "RTX 2060 SUPER", 60, 2500.00m });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Nome", "Quantidade", "Valor" },
                values: new object[] { new Guid("57f6ce8a-1e54-4d30-9332-d9c5cbf186ce"), "RTX 2070", 10, 3000.00m });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Nome", "Quantidade", "Valor" },
                values: new object[] { new Guid("7415f8ce-e427-4a87-9a13-9be812ddaf4b"), "RTX 2070 SUPER", 8, 3500.00m });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Nome", "Quantidade", "Valor" },
                values: new object[] { new Guid("1aad9964-b9e3-4f46-99e2-6ad12fa1779f"), "RTX 2080 SUPER", 5, 4000.00m });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Nome", "Quantidade", "Valor" },
                values: new object[] { new Guid("dbc4c222-4b5a-4f41-bffe-90cffb20b781"), "RTX 2080", 1, 6000.00m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}

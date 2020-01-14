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
                values: new object[] { new Guid("67fa5aaf-579e-4086-876a-846a5e3264a7"), "RTX 2060", 50, 2000.00m });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Nome", "Quantidade", "Valor" },
                values: new object[] { new Guid("b7a7294b-9d41-4cf5-b778-73ed6ee12597"), "RTX 2060 SUPER", 60, 2500.00m });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Nome", "Quantidade", "Valor" },
                values: new object[] { new Guid("9ef9b714-5a63-492b-95a2-2e7fedf350b9"), "RTX 2070", 10, 3000.00m });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Nome", "Quantidade", "Valor" },
                values: new object[] { new Guid("9f823f33-1655-46f8-9858-cf0387292ac3"), "RTX 2070 SUPER", 8, 3500.00m });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Nome", "Quantidade", "Valor" },
                values: new object[] { new Guid("bb414e49-3ee3-4221-9475-9062f4e95a82"), "RTX 2080 SUPER", 5, 4000.00m });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Nome", "Quantidade", "Valor" },
                values: new object[] { new Guid("343a7faf-1657-48fd-912e-af42e996e146"), "RTX 2080", 1, 6000.00m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}

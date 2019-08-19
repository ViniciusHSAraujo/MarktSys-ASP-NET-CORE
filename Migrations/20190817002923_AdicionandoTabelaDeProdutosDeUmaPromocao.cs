using Microsoft.EntityFrameworkCore.Migrations;

namespace MarktSys_ASP_NET_CORE.Migrations
{
    public partial class AdicionandoTabelaDeProdutosDeUmaPromocao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PromocoesProdutos",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(nullable: false),
                    PromocaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromocoesProdutos", x => new { x.PromocaoId, x.ProdutoId });
                    table.ForeignKey(
                        name: "FK_PromocoesProdutos_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PromocoesProdutos_Promocoes_PromocaoId",
                        column: x => x.PromocaoId,
                        principalTable: "Promocoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PromocoesProdutos_ProdutoId",
                table: "PromocoesProdutos",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PromocoesProdutos");
        }
    }
}

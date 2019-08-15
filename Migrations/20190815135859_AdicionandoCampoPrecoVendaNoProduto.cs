using Microsoft.EntityFrameworkCore.Migrations;

namespace MarktSys_ASP_NET_CORE.Migrations
{
    public partial class AdicionandoCampoPrecoVendaNoProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "PrecoVenda",
                table: "Produtos",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoVenda",
                table: "Produtos");
        }
    }
}

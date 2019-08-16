using Microsoft.EntityFrameworkCore.Migrations;

namespace MarktSys_ASP_NET_CORE.Migrations {
    public partial class AdicionandoStatusNaUnidade : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Unidades",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Unidades");
        }
    }
}

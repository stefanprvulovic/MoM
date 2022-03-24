using Microsoft.EntityFrameworkCore.Migrations;

namespace MoM.Migrations
{
    public partial class V7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ministarstvoid",
                table: "Odsek",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ministarstvo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Brojspratova = table.Column<int>(name: "Broj spratova", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ministarstvo", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Odsek_Ministarstvoid",
                table: "Odsek",
                column: "Ministarstvoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Odsek_Ministarstvo_Ministarstvoid",
                table: "Odsek",
                column: "Ministarstvoid",
                principalTable: "Ministarstvo",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Odsek_Ministarstvo_Ministarstvoid",
                table: "Odsek");

            migrationBuilder.DropTable(
                name: "Ministarstvo");

            migrationBuilder.DropIndex(
                name: "IX_Odsek_Ministarstvoid",
                table: "Odsek");

            migrationBuilder.DropColumn(
                name: "Ministarstvoid",
                table: "Odsek");
        }
    }
}

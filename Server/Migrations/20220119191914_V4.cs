using Microsoft.EntityFrameworkCore.Migrations;

namespace MoM.Migrations
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Br. radnika",
                table: "Odsek");

            migrationBuilder.DropColumn(
                name: "Br. slučajeva",
                table: "Odsek");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Br. radnika",
                table: "Odsek",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Br. slučajeva",
                table: "Odsek",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

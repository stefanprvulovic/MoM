using Microsoft.EntityFrameworkCore.Migrations;

namespace MoM.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Radnik_Odsek_OdsekID",
                table: "Radnik");

            migrationBuilder.DropForeignKey(
                name: "FK_Slučaj_Odsek_OdsekID",
                table: "Slučaj");

            migrationBuilder.DropForeignKey(
                name: "FK_Slučaj_Radnik_RadnikID",
                table: "Slučaj");

            migrationBuilder.RenameColumn(
                name: "RadnikID",
                table: "Slučaj",
                newName: "Radnikid");

            migrationBuilder.RenameColumn(
                name: "OdsekID",
                table: "Slučaj",
                newName: "Odsekid");

            migrationBuilder.RenameIndex(
                name: "IX_Slučaj_RadnikID",
                table: "Slučaj",
                newName: "IX_Slučaj_Radnikid");

            migrationBuilder.RenameIndex(
                name: "IX_Slučaj_OdsekID",
                table: "Slučaj",
                newName: "IX_Slučaj_Odsekid");

            migrationBuilder.RenameColumn(
                name: "OdsekID",
                table: "Radnik",
                newName: "Odsekid");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Radnik",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Radnik_OdsekID",
                table: "Radnik",
                newName: "IX_Radnik_Odsekid");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Odsek",
                newName: "id");

            migrationBuilder.AlterColumn<int>(
                name: "Br. legitimacije",
                table: "Radnik",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Radnik_Odsek_Odsekid",
                table: "Radnik",
                column: "Odsekid",
                principalTable: "Odsek",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Slučaj_Odsek_Odsekid",
                table: "Slučaj",
                column: "Odsekid",
                principalTable: "Odsek",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Slučaj_Radnik_Radnikid",
                table: "Slučaj",
                column: "Radnikid",
                principalTable: "Radnik",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Radnik_Odsek_Odsekid",
                table: "Radnik");

            migrationBuilder.DropForeignKey(
                name: "FK_Slučaj_Odsek_Odsekid",
                table: "Slučaj");

            migrationBuilder.DropForeignKey(
                name: "FK_Slučaj_Radnik_Radnikid",
                table: "Slučaj");

            migrationBuilder.RenameColumn(
                name: "Radnikid",
                table: "Slučaj",
                newName: "RadnikID");

            migrationBuilder.RenameColumn(
                name: "Odsekid",
                table: "Slučaj",
                newName: "OdsekID");

            migrationBuilder.RenameIndex(
                name: "IX_Slučaj_Radnikid",
                table: "Slučaj",
                newName: "IX_Slučaj_RadnikID");

            migrationBuilder.RenameIndex(
                name: "IX_Slučaj_Odsekid",
                table: "Slučaj",
                newName: "IX_Slučaj_OdsekID");

            migrationBuilder.RenameColumn(
                name: "Odsekid",
                table: "Radnik",
                newName: "OdsekID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Radnik",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Radnik_Odsekid",
                table: "Radnik",
                newName: "IX_Radnik_OdsekID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Odsek",
                newName: "ID");

            migrationBuilder.AlterColumn<string>(
                name: "Br. legitimacije",
                table: "Radnik",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Radnik_Odsek_OdsekID",
                table: "Radnik",
                column: "OdsekID",
                principalTable: "Odsek",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Slučaj_Odsek_OdsekID",
                table: "Slučaj",
                column: "OdsekID",
                principalTable: "Odsek",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Slučaj_Radnik_RadnikID",
                table: "Slučaj",
                column: "RadnikID",
                principalTable: "Radnik",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

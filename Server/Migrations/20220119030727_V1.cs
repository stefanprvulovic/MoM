using Microsoft.EntityFrameworkCore.Migrations;

namespace MoM.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Odsek",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Brsprata = table.Column<int>(name: "Br. sprata", type: "int", nullable: false),
                    Brradnika = table.Column<int>(name: "Br. radnika", type: "int", nullable: false),
                    Brslučajeva = table.Column<int>(name: "Br. slučajeva", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odsek", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Radnik",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Pol = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Brlegitimacije = table.Column<string>(name: "Br. legitimacije", type: "nvarchar(7)", maxLength: 7, nullable: true),
                    Godinarođenja = table.Column<int>(name: "Godina rođenja", type: "int", maxLength: 4, nullable: false),
                    OdsekID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radnik", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Radnik_Odsek_OdsekID",
                        column: x => x.OdsekID,
                        principalTable: "Odsek",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Slučaj",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kodnoime = table.Column<string>(name: "Kodno ime", type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Nivopoverljivosti = table.Column<string>(name: "Nivo poverljivosti", type: "nvarchar(max)", nullable: true),
                    RadnikID = table.Column<int>(type: "int", nullable: true),
                    OdsekID = table.Column<int>(type: "int", nullable: true),
                    Kratakopis = table.Column<string>(name: "Kratak opis", type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slučaj", x => x.id);
                    table.ForeignKey(
                        name: "FK_Slučaj_Odsek_OdsekID",
                        column: x => x.OdsekID,
                        principalTable: "Odsek",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Slučaj_Radnik_RadnikID",
                        column: x => x.RadnikID,
                        principalTable: "Radnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Radnik_OdsekID",
                table: "Radnik",
                column: "OdsekID");

            migrationBuilder.CreateIndex(
                name: "IX_Slučaj_OdsekID",
                table: "Slučaj",
                column: "OdsekID");

            migrationBuilder.CreateIndex(
                name: "IX_Slučaj_RadnikID",
                table: "Slučaj",
                column: "RadnikID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Slučaj");

            migrationBuilder.DropTable(
                name: "Radnik");

            migrationBuilder.DropTable(
                name: "Odsek");
        }
    }
}

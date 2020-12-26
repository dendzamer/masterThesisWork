using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albumi",
                columns: table => new
                {
                    AlbumId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naziv = table.Column<string>(type: "TEXT", nullable: true),
                    GodinaIzdanja = table.Column<int>(type: "INTEGER", nullable: false),
                    KataloskiBroj = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albumi", x => x.AlbumId);
                });

            migrationBuilder.CreateTable(
                name: "Izvodjaci",
                columns: table => new
                {
                    IzvodjacId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naziv = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Izvodjaci", x => x.IzvodjacId);
                });

            migrationBuilder.CreateTable(
                name: "Fonogrami",
                columns: table => new
                {
                    FonogramId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naziv = table.Column<string>(type: "TEXT", nullable: true),
                    GodinaIzdanja = table.Column<int>(type: "INTEGER", nullable: false),
                    KataloskiBroj = table.Column<string>(type: "TEXT", nullable: true),
                    AlbumId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fonogrami", x => x.FonogramId);
                    table.ForeignKey(
                        name: "FK_Fonogrami_Albumi_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albumi",
                        principalColumn: "AlbumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FonogramIzvodjac",
                columns: table => new
                {
                    FonogramId = table.Column<int>(type: "INTEGER", nullable: false),
                    IzvodjacId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FonogramIzvodjac", x => new { x.FonogramId, x.IzvodjacId });
                    table.ForeignKey(
                        name: "FK_FonogramIzvodjac_Fonogrami_FonogramId",
                        column: x => x.FonogramId,
                        principalTable: "Fonogrami",
                        principalColumn: "FonogramId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FonogramIzvodjac_Izvodjaci_IzvodjacId",
                        column: x => x.IzvodjacId,
                        principalTable: "Izvodjaci",
                        principalColumn: "IzvodjacId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fonogrami_AlbumId",
                table: "Fonogrami",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_FonogramIzvodjac_IzvodjacId",
                table: "FonogramIzvodjac",
                column: "IzvodjacId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FonogramIzvodjac");

            migrationBuilder.DropTable(
                name: "Fonogrami");

            migrationBuilder.DropTable(
                name: "Izvodjaci");

            migrationBuilder.DropTable(
                name: "Albumi");
        }
    }
}

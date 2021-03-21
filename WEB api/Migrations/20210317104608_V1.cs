using Microsoft.EntityFrameworkCore.Migrations;

namespace WEB_api.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Evidencija",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeDrzave = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evidencija", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Kategorije",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kategorije = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorije", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Lokacija",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeVozaca = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PrezimeVozaca = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BrojDozvole = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Grad = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    JMBG = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    KategorijeID = table.Column<int>(type: "int", nullable: true),
                    EvidencijaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokacija", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Lokacija_Evidencija_EvidencijaID",
                        column: x => x.EvidencijaID,
                        principalTable: "Evidencija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lokacija_Kategorije_KategorijeID",
                        column: x => x.KategorijeID,
                        principalTable: "Kategorije",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lokacija_EvidencijaID",
                table: "Lokacija",
                column: "EvidencijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Lokacija_KategorijeID",
                table: "Lokacija",
                column: "KategorijeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lokacija");

            migrationBuilder.DropTable(
                name: "Evidencija");

            migrationBuilder.DropTable(
                name: "Kategorije");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace WEB_api.Migrations
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vozacka_Evidencija_EvidencijaID",
                table: "Vozacka");

            migrationBuilder.DropForeignKey(
                name: "FK_Vozacka_Kategorije_KategorijeID",
                table: "Vozacka");

            migrationBuilder.DropIndex(
                name: "IX_Vozacka_KategorijeID",
                table: "Vozacka");

            migrationBuilder.DropColumn(
                name: "KategorijeID",
                table: "Vozacka");

            migrationBuilder.RenameColumn(
                name: "EvidencijaID",
                table: "Vozacka",
                newName: "evidencijaID");

            migrationBuilder.RenameIndex(
                name: "IX_Vozacka_EvidencijaID",
                table: "Vozacka",
                newName: "IX_Vozacka_evidencijaID");

            migrationBuilder.AddColumn<int>(
                name: "vozacID",
                table: "Kategorije",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kategorije_vozacID",
                table: "Kategorije",
                column: "vozacID");

            migrationBuilder.AddForeignKey(
                name: "FK_Kategorije_Vozacka_vozacID",
                table: "Kategorije",
                column: "vozacID",
                principalTable: "Vozacka",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vozacka_Evidencija_evidencijaID",
                table: "Vozacka",
                column: "evidencijaID",
                principalTable: "Evidencija",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kategorije_Vozacka_vozacID",
                table: "Kategorije");

            migrationBuilder.DropForeignKey(
                name: "FK_Vozacka_Evidencija_evidencijaID",
                table: "Vozacka");

            migrationBuilder.DropIndex(
                name: "IX_Kategorije_vozacID",
                table: "Kategorije");

            migrationBuilder.DropColumn(
                name: "vozacID",
                table: "Kategorije");

            migrationBuilder.RenameColumn(
                name: "evidencijaID",
                table: "Vozacka",
                newName: "EvidencijaID");

            migrationBuilder.RenameIndex(
                name: "IX_Vozacka_evidencijaID",
                table: "Vozacka",
                newName: "IX_Vozacka_EvidencijaID");

            migrationBuilder.AddColumn<int>(
                name: "KategorijeID",
                table: "Vozacka",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vozacka_KategorijeID",
                table: "Vozacka",
                column: "KategorijeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vozacka_Evidencija_EvidencijaID",
                table: "Vozacka",
                column: "EvidencijaID",
                principalTable: "Evidencija",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vozacka_Kategorije_KategorijeID",
                table: "Vozacka",
                column: "KategorijeID",
                principalTable: "Kategorije",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

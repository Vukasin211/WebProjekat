using Microsoft.EntityFrameworkCore.Migrations;

namespace WEB_api.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lokacija_Evidencija_EvidencijaID",
                table: "Lokacija");

            migrationBuilder.DropForeignKey(
                name: "FK_Lokacija_Kategorije_KategorijeID",
                table: "Lokacija");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lokacija",
                table: "Lokacija");

            migrationBuilder.RenameTable(
                name: "Lokacija",
                newName: "Vozacka");

            migrationBuilder.RenameIndex(
                name: "IX_Lokacija_KategorijeID",
                table: "Vozacka",
                newName: "IX_Vozacka_KategorijeID");

            migrationBuilder.RenameIndex(
                name: "IX_Lokacija_EvidencijaID",
                table: "Vozacka",
                newName: "IX_Vozacka_EvidencijaID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vozacka",
                table: "Vozacka",
                column: "ID");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vozacka_Evidencija_EvidencijaID",
                table: "Vozacka");

            migrationBuilder.DropForeignKey(
                name: "FK_Vozacka_Kategorije_KategorijeID",
                table: "Vozacka");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vozacka",
                table: "Vozacka");

            migrationBuilder.RenameTable(
                name: "Vozacka",
                newName: "Lokacija");

            migrationBuilder.RenameIndex(
                name: "IX_Vozacka_KategorijeID",
                table: "Lokacija",
                newName: "IX_Lokacija_KategorijeID");

            migrationBuilder.RenameIndex(
                name: "IX_Vozacka_EvidencijaID",
                table: "Lokacija",
                newName: "IX_Lokacija_EvidencijaID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lokacija",
                table: "Lokacija",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Lokacija_Evidencija_EvidencijaID",
                table: "Lokacija",
                column: "EvidencijaID",
                principalTable: "Evidencija",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lokacija_Kategorije_KategorijeID",
                table: "Lokacija",
                column: "KategorijeID",
                principalTable: "Kategorije",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

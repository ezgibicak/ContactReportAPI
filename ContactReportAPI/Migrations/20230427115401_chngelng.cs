using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactReportAPI.Migrations
{
    public partial class chngelng : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Iletisim_Kisi_PersonId",
                table: "Iletisim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kisi",
                table: "Kisi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Iletisim",
                table: "Iletisim");

            migrationBuilder.RenameTable(
                name: "Kisi",
                newName: "Person");

            migrationBuilder.RenameTable(
                name: "Iletisim",
                newName: "Contact");

            migrationBuilder.RenameIndex(
                name: "IX_Iletisim_PersonId",
                table: "Contact",
                newName: "IX_Contact_PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contact",
                table: "Contact",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Person_PersonId",
                table: "Contact",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Person_PersonId",
                table: "Contact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contact",
                table: "Contact");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "Kisi");

            migrationBuilder.RenameTable(
                name: "Contact",
                newName: "Iletisim");

            migrationBuilder.RenameIndex(
                name: "IX_Contact_PersonId",
                table: "Iletisim",
                newName: "IX_Iletisim_PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kisi",
                table: "Kisi",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Iletisim",
                table: "Iletisim",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Iletisim_Kisi_PersonId",
                table: "Iletisim",
                column: "PersonId",
                principalTable: "Kisi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

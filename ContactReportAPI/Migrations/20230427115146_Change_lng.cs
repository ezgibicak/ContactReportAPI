using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactReportAPI.Migrations
{
    public partial class Change_lng : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Iletisim_Kisi_KisiId",
                table: "Iletisim");

            migrationBuilder.RenameColumn(
                name: "Soyad",
                table: "Kisi",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "Firma",
                table: "Kisi",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Ad",
                table: "Kisi",
                newName: "Firm");

            migrationBuilder.RenameColumn(
                name: "TelefonNumarasi",
                table: "Iletisim",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "KisiId",
                table: "Iletisim",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Iletisim_KisiId",
                table: "Iletisim",
                newName: "IX_Iletisim_PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Iletisim_Kisi_PersonId",
                table: "Iletisim",
                column: "PersonId",
                principalTable: "Kisi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Iletisim_Kisi_PersonId",
                table: "Iletisim");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Kisi",
                newName: "Soyad");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Kisi",
                newName: "Firma");

            migrationBuilder.RenameColumn(
                name: "Firm",
                table: "Kisi",
                newName: "Ad");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Iletisim",
                newName: "TelefonNumarasi");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Iletisim",
                newName: "KisiId");

            migrationBuilder.RenameIndex(
                name: "IX_Iletisim_PersonId",
                table: "Iletisim",
                newName: "IX_Iletisim_KisiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Iletisim_Kisi_KisiId",
                table: "Iletisim",
                column: "KisiId",
                principalTable: "Kisi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

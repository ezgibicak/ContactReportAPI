using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactReportAPI.Migrations
{
    public partial class Iletisim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Iletisim_Kisi_KisiId",
                table: "Iletisim");

            migrationBuilder.DropTable(
                name: "KisiIletisim");

            migrationBuilder.AlterColumn<Guid>(
                name: "KisiId",
                table: "Iletisim",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Iletisim_Kisi_KisiId",
                table: "Iletisim",
                column: "KisiId",
                principalTable: "Kisi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Iletisim_Kisi_KisiId",
                table: "Iletisim");

            migrationBuilder.AlterColumn<Guid>(
                name: "KisiId",
                table: "Iletisim",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateTable(
                name: "KisiIletisim",
                columns: table => new
                {
                    IletisimId = table.Column<int>(type: "integer", nullable: false),
                    KisiId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Iletisim_Kisi_KisiId",
                table: "Iletisim",
                column: "KisiId",
                principalTable: "Kisi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

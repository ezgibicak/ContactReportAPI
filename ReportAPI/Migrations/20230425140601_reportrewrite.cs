using Microsoft.EntityFrameworkCore.Migrations;

namespace ReportAPI.Migrations
{
    public partial class reportrewrite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KayitliKisi",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "KayitliTelefonNo",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Report");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Report",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "Report");

            migrationBuilder.AddColumn<int>(
                name: "KayitliKisi",
                table: "Report",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KayitliTelefonNo",
                table: "Report",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Report",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Report",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    public partial class UpdateDataTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Time",
                table: "Data",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<double>(
                name: "SensFx",
                table: "Data",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SensFy",
                table: "Data",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SensFz",
                table: "Data",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SensTx",
                table: "Data",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SensTy",
                table: "Data",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SensTz",
                table: "Data",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SensFx",
                table: "Data");

            migrationBuilder.DropColumn(
                name: "SensFy",
                table: "Data");

            migrationBuilder.DropColumn(
                name: "SensFz",
                table: "Data");

            migrationBuilder.DropColumn(
                name: "SensTx",
                table: "Data");

            migrationBuilder.DropColumn(
                name: "SensTy",
                table: "Data");

            migrationBuilder.DropColumn(
                name: "SensTz",
                table: "Data");

            migrationBuilder.AlterColumn<double>(
                name: "Time",
                table: "Data",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}

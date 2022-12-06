using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Batch",
                columns: table => new
                {
                    BatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTs = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTs = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batch", x => x.BatchId);
                });

            migrationBuilder.CreateTable(
                name: "Screw",
                columns: table => new
                {
                    ScrewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTs = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StopTs = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ok = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screw", x => x.ScrewId);
                    table.ForeignKey(
                        name: "FK_Screw_Batch_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Batch",
                        principalColumn: "BatchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Data",
                columns: table => new
                {
                    DataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<double>(type: "float", nullable: false),
                    TcpFx = table.Column<double>(type: "float", nullable: false),
                    TcpFy = table.Column<double>(type: "float", nullable: false),
                    TcpFz = table.Column<double>(type: "float", nullable: false),
                    TcpTx = table.Column<double>(type: "float", nullable: false),
                    TcpTy = table.Column<double>(type: "float", nullable: false),
                    TcpTz = table.Column<double>(type: "float", nullable: false),
                    Ta7 = table.Column<double>(type: "float", nullable: false),
                    PhiScrew = table.Column<double>(type: "float", nullable: false),
                    ScrewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Data", x => x.DataId);
                    table.ForeignKey(
                        name: "FK_Data_Screw_ScrewId",
                        column: x => x.ScrewId,
                        principalTable: "Screw",
                        principalColumn: "ScrewId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Data_ScrewId",
                table: "Data",
                column: "ScrewId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Screw_BatchId",
                table: "Screw",
                column: "BatchId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Data");

            migrationBuilder.DropTable(
                name: "Screw");

            migrationBuilder.DropTable(
                name: "Batch");
        }
    }
}

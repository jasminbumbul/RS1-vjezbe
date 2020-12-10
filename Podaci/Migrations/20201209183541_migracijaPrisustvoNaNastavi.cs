using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Podaci.Migrations
{
    public partial class migracijaPrisustvoNaNastavi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrisustvoNaNastavi",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(nullable: false),
                    StudentID = table.Column<int>(nullable: false),
                    PredmetID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrisustvoNaNastavi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PrisustvoNaNastavi_Predmet_PredmetID",
                        column: x => x.PredmetID,
                        principalTable: "Predmet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrisustvoNaNastavi_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrisustvoNaNastavi_PredmetID",
                table: "PrisustvoNaNastavi",
                column: "PredmetID");

            migrationBuilder.CreateIndex(
                name: "IX_PrisustvoNaNastavi_StudentID",
                table: "PrisustvoNaNastavi",
                column: "StudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrisustvoNaNastavi");
        }
    }
}

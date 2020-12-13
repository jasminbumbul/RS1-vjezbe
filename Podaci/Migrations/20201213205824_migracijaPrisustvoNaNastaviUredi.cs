using Microsoft.EntityFrameworkCore.Migrations;

namespace Podaci.Migrations
{
    public partial class migracijaPrisustvoNaNastaviUredi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Komentar",
                table: "PrisustvoNaNastavi",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Prisutan",
                table: "PrisustvoNaNastavi",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Komentar",
                table: "PrisustvoNaNastavi");

            migrationBuilder.DropColumn(
                name: "Prisutan",
                table: "PrisustvoNaNastavi");
        }
    }
}

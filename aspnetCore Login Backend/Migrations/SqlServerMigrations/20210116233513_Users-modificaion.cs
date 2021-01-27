using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations.SqlServerMigrations
{
    public partial class Usersmodificaion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CorreoElectronico",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cuil",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DNI",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Domicilio",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Saldo",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorreoElectronico",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Cuil",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DNI",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Domicilio",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Saldo",
                table: "Users");
        }
    }
}

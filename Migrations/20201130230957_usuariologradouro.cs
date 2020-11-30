using Microsoft.EntityFrameworkCore.Migrations;

namespace VendasWEB.Migrations
{
    public partial class usuariologradouro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Localidade",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Localidade",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Localidade",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Localidade",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

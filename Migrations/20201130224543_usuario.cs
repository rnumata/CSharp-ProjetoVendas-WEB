using Microsoft.EntityFrameworkCore.Migrations;

namespace VendasWEB.Migrations
{
    public partial class usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Uf",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Uf",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Uf",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Uf",
                table: "AspNetUsers");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoUsuario.Persistence.Migrations
{
    public partial class CollumDatasPerfil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "data_criacao_perfil",
                table: "perfil",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "data_ultima_atualizacao_pefil",
                table: "perfil",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "data_criacao_perfil",
                table: "perfil");

            migrationBuilder.DropColumn(
                name: "data_ultima_atualizacao_pefil",
                table: "perfil");
        }
    }
}

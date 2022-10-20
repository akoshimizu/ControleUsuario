using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoUsuario.Persistence.Migrations
{
    public partial class CreateSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "mesa",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descricao_mesa = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    indicador_mesa = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    data_criacao_mesa = table.Column<DateTime>(type: "datetime", nullable: false),
                    data_ultima_alteracao_mesa = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mesa", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "perfil",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descricao_perfil = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    indicador_perfil = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    data_criacao_perfil = table.Column<DateTime>(type: "datetime", nullable: false),
                    data_ultima_atualizacao_pefil = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfil", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome_usuario = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PerfilId = table.Column<int>(type: "int", nullable: true),
                    email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MesaId = table.Column<int>(type: "int", nullable: true),
                    indicador_usuario = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.id);
                    table.ForeignKey(
                        name: "FK_usuario_mesa_MesaId",
                        column: x => x.MesaId,
                        principalTable: "mesa",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_usuario_perfil_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "perfil",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "mesa_usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioRefId = table.Column<int>(type: "int", nullable: true),
                    MesaRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mesa_usuario", x => x.id);
                    table.ForeignKey(
                        name: "FK_mesa_usuario_mesa_MesaRefId",
                        column: x => x.MesaRefId,
                        principalTable: "mesa",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_mesa_usuario_usuario_UsuarioRefId",
                        column: x => x.UsuarioRefId,
                        principalTable: "usuario",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_mesa_usuario_MesaRefId",
                table: "mesa_usuario",
                column: "MesaRefId");

            migrationBuilder.CreateIndex(
                name: "IX_mesa_usuario_UsuarioRefId",
                table: "mesa_usuario",
                column: "UsuarioRefId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuario_MesaId",
                table: "usuario",
                column: "MesaId");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_PerfilId",
                table: "usuario",
                column: "PerfilId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mesa_usuario");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "mesa");

            migrationBuilder.DropTable(
                name: "perfil");
        }
    }
}

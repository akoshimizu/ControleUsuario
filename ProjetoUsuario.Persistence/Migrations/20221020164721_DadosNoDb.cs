using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoUsuario.Persistence.Migrations
{
    public partial class DadosNoDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into mesa(descricao_mesa, indicador_mesa, data_criacao_mesa, data_ultima_alteracao_mesa) VALUES " +
            "('Mesa 1', true, '2022/10/01', '2022/10/01'), "+
            "('Mesa 2', true, '2022/10/01', '2022/10/01'), "+
            "('Mesa 3', true, '2022/10/01', '2022/10/01'), "+ 
            "('Mesa 4', true, '2022/10/01', '2022/10/01')," +
            "('Mesa 5', true, '2022/10/01', '2022/10/01');");


            migrationBuilder.Sql("insert into perfil(descricao_perfil, indicador_perfil, data_criacao_perfil, data_ultima_atualizacao_pefil) values " +
            "('Perfil 1', true, '2022/10/01', '2022/10/01'), " +
            "('Perfil 2', true, '2022/10/01', '2022/10/01'), " +
            "('Perfil 3', true, '2022/10/01', '2022/10/01'), " +
            "('Perfil 4', true, '2022/10/01', '2022/10/01'), " +
            "('Perfil 5', true, '2022/10/01', '2022/10/01');"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE from mesa");
            migrationBuilder.Sql("DELETE from perfil");
        }
    }
}

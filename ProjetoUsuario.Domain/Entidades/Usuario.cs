using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoUsuario.Domain.Entidades
{
    [Table("usuario")]
    public class Usuario
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nome_usuario")]
        public string NomeUsuario { get; set; }

        [Column("PerfilId")]
        public Perfil Perfil { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("MesaId")]
        public Mesa Mesa { get; set; }

        [Column("ListaMesasId")]
        public List<MesaUsuario> MesasdoUsuario { get; set; }

        [Column("indicador_usuario")]
        public bool IndicadorUsuarioAtivo { get; set; }
    }
}
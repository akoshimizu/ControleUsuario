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

        [Column("codigo_perfil")]
        public int CodPerfil { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("codigo_mesa")]
        public int CodMesa { get; set; }

        [Column("indicador_usuario")]
        public bool IndicadorUsuarioAtivo { get; set; }
    }
}
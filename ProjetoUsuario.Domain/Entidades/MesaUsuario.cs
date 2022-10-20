using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoUsuario.Domain.Entidades
{
    [Table("mesa_usuario")]
    public class MesaUsuario
    {
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("UsuarioRefId")]
        public Usuario Usuario { get; set; }

        [ForeignKey("MesaRefId")]
        public Mesa Mesa { get; set; }
    }
}
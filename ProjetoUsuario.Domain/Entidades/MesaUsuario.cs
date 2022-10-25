using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoUsuario.Domain.Entidades
{
    [Table("mesa_usuario")]
    public class MesaUsuario
    {
        public int Id {get; set; }

        [ForeignKey("usuarioId")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        [ForeignKey("mesaId")]
        public int MesaId { get; set; }
        public Mesa Mesa { get; set; }
    }
}
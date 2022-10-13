using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoUsuario.Domain.Entidades
{
    [Table("perfil")]
    public class Perfil
    {
        [Column("id")]
        public int Id { get; set; }
        
        [Column("descricao_perfil")]
        [StringLength(10, ErrorMessage = "Máximo de 10 Caracteres")]
        public string DescricaoPerfil { get; set; }

        [Column("indicador_perfil")]
        public bool IndicadorPerfil { get; set; }
    }
}
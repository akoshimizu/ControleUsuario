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
        
        public string DescricaoPerfil { get; set; }

        [Column("indicador_perfil")]
        public bool IndicadorPerfil { get; set; }

        [Column("data_criacao_perfil")]
        public DateTime DataCriacaoPerfil { get; set; }

        [Column("data_ultima_atualizacao_pefil")]
        public DateTime DataUltimaAtualizacao { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace ProjetoUsuario.Domain.DTO
{
    public class PerfilDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Insira a descrição do perfil")]
        [StringLength(100, MinimumLength = 5,  ErrorMessage = "Máximo de 100 e Min de 5 Caracteres.")]
        public string DescricaoPerfil { get; set; }

        [Required(ErrorMessage = "Indique 'true' ou 'false' ")]
        public bool IndicadorPerfil { get; set; }

        //[DataType(DataType.DateTime)]
        //public DateTime DataCriacaoPerfil { get; set; }
        
        //[DataType(DataType.DateTime)]
        //public DateTime DataUltimaAtualizacao { get; set; }
    }
}
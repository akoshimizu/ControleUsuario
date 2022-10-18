using System.ComponentModel.DataAnnotations;

namespace ProjetoUsuario.Domain.DTO
{
    public class MesaDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Insira a descrição da mesa")]
        [StringLength(100, MinimumLength = 5,  ErrorMessage = "Máximo de 100 e Min de 5 Caracteres.")]
        public string DescricaoMesa { get; set; }

        [Required(ErrorMessage = "Indique 'true' ou 'false' ")]
        public bool IndicarorMesaAtiva { get; set; }
    }
}
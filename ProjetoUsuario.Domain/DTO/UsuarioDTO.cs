using System.ComponentModel.DataAnnotations;

namespace ProjetoUsuario.Domain.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Insira o nome de usuário")]
        [StringLength(255, ErrorMessage = "Max 255 Caracteres")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "Insira o código do Perfil")]
        public int CodPerfil { get; set; }

        [Required(ErrorMessage = "Insira um email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Insira um email válido")]
        [StringLength(255, ErrorMessage = "Max 255 Caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Insira o código da mesa")]
        public int CodMesa { get; set; }
        public bool IndicadorUsuarioAtivo { get; set; }

        //Felipe - 1 usuário X N mesas (só o código)
        public List<int> Mesas { get; set; }
    }
}
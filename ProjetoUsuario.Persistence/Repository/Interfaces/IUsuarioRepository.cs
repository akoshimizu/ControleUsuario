using ProjetoUsuario.Domain.DTO;
using ProjetoUsuario.Domain.Entidades;

namespace ProjetoUsuario.Persistence.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario FindById(int id);
        List<Usuario> FindAllUsuario();
        Usuario Create(UsuarioDTO usuario);
        Usuario UpdateUsuario(UsuarioDTO usuario);
        void DeleteUsuario(int id);
        bool VerificaDuplicidadeUsuario(Usuario Usuario);
    }
}
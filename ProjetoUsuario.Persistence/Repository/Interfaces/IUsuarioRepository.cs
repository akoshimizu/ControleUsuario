using ProjetoUsuario.Domain.Entidades;

namespace ProjetoUsuario.Persistence.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario FindById(int id);
        List<Usuario> FindAllUsuario();
        Usuario Create(Usuario Usuario);
        Usuario UpdateUsuario(Usuario Usuario);
        void DeleteUsuario(int id);
        bool VerificaDuplicidadeUsuario(Usuario Usuario);
    }
}
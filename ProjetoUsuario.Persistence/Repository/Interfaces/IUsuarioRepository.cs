using ProjetoUsuario.Domain.DTO;
using ProjetoUsuario.Domain.Entidades;

namespace ProjetoUsuario.Persistence.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario BuscarUsuarioPorId(int id);
        List<Usuario> BuscarTodosUsuarios();
        Usuario CriarUsuario(UsuarioDTO usuario);
        Usuario AtualizarUsuario(UsuarioDTO usuario);
        void DeletarUsuario(int id);
        bool VerificaDuplicidadeUsuario(Usuario Usuario);
        MesaDTO AdicionarMesa(int id, MesaDTO mesa);
        List<MesaUsuario> BuscarMesasDoUsuario(int id);
    }
}
using ProjetoUsuario.Domain.DTO;
using ProjetoUsuario.Domain.Entidades;

namespace ProjetoUsuario.Application.Interfaces
{
    public interface IUsuarioService
    {
        Usuario BuscarUsuarioId(int id);
        List<Usuario> BuscarTodosUsuarios();
        Usuario CriarUsuario(UsuarioDTO Usuario);
        Usuario AtualizarUsuario(UsuarioDTO Usuario);
        void DesativarUsuario(int id);
        MesaDTO AdicionarMesa(int id, MesaDTO mesa);
    }
}
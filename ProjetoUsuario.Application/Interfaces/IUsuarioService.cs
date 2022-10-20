using ProjetoUsuario.Domain.DTO;
using ProjetoUsuario.Domain.Entidades;

namespace ProjetoUsuario.Application.Interfaces
{
    public interface IUsuarioService
    {
        Usuario FindById(int id);
        List<Usuario> FindAllUsuario();
        Usuario Create(UsuarioDTO Usuario);
        Usuario UpdateUsuario(UsuarioDTO Usuario);
        void DeleteUsuario(int id);
        MesaDTO AdicionarMesa(int id, MesaDTO mesa);
    }
}
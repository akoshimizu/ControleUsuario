using ProjetoUsuario.Application.Interfaces;
using ProjetoUsuario.Domain.DTO;
using ProjetoUsuario.Domain.Entidades;
using ProjetoUsuario.Persistence.Context;
using ProjetoUsuario.Persistence.Repository.Interfaces;

namespace ProjetoUsuario.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public List<Usuario> BuscarTodosUsuarios()
        {
            return _usuarioRepository.BuscarTodosUsuarios();
        }

        public Usuario BuscarUsuarioId(int id)
        {
            return _usuarioRepository.BuscarUsuarioPorId(id);
        }

        public Usuario CriarUsuario(UsuarioDTO usuario)
        {
                var usuarioAtualizado = _usuarioRepository.CriarUsuario(usuario);
                return usuarioAtualizado;
        }

        public Usuario AtualizarUsuario(UsuarioDTO usuarioDTO)
        {
            var usuarioAtualizado = _usuarioRepository.AtualizarUsuario(usuarioDTO);
            return usuarioAtualizado;
        }

        public void DesativarUsuario(int id)
        {
            _usuarioRepository.DeletarUsuario(id);
        }
    }
}
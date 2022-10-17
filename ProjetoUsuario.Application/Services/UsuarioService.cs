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

        public List<Usuario> FindAllUsuario()
        {
            return _usuarioRepository.FindAllUsuario();
        }

        public Usuario FindById(int id)
        {
            return _usuarioRepository.FindById(id);
        }

        public Usuario Create(UsuarioDTO usuario)
        {
                var usuarioAtualizado = _usuarioRepository.Create(usuario);
                return usuarioAtualizado;
        }

        public Usuario UpdateUsuario(UsuarioDTO usuarioDTO)
        {
            // Usuario usuario = new Usuario();
            // usuario.Id = usuarioDTO.Id;
            // usuario.NomeUsuario = usuarioDTO.NomeUsuario;
            // usuario.Email = usuarioDTO.Email;
            // usuario.Perfil = _context.Perfis.First(per => per.Id.Equals(usuarioDTO.CodPerfil));
            // usuario.CodMesa = usuarioDTO.CodMesa;
            // usuario.IndicadorUsuarioAtivo = usuarioDTO.IndicadorUsuarioAtivo;

            //var verificaUsuario = _usuarioRepository.VerificaDuplicidadeUsuario(usuario);

            var usuarioAtualizado = _usuarioRepository.UpdateUsuario(usuarioDTO);
            return usuarioAtualizado;
        }

        public void DeleteUsuario(int id)
        {
            _usuarioRepository.DeleteUsuario(id);
        }
    }
}
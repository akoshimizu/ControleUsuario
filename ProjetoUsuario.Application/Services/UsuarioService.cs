using ProjetoUsuario.Application.Interfaces;
using ProjetoUsuario.Domain.DTO;
using ProjetoUsuario.Domain.Entidades;
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
            Usuario criarUsuario = new Usuario();
            criarUsuario.Id = usuario.Id;
            criarUsuario.NomeUsuario = usuario.NomeUsuario;
            criarUsuario.Email  = usuario.Email;
            criarUsuario.CodPerfil = usuario.CodPerfil;
            criarUsuario.CodMesa = usuario.CodMesa;
            criarUsuario.IndicadorUsuarioAtivo = usuario.IndicadorUsuarioAtivo;

            var verificaUsuario = _usuarioRepository.VerificaDuplicidadeUsuario(criarUsuario);
            if(verificaUsuario.Equals(false))
            {
                var usuarioAtualizado = _usuarioRepository.Create(criarUsuario);
                return usuarioAtualizado;
            }
            return null;
        }

        public Usuario UpdateUsuario(UsuarioDTO usuarioDTO)
        {
            Usuario usuario = new Usuario();
            usuario.Id = usuarioDTO.Id;
            usuario.NomeUsuario = usuarioDTO.NomeUsuario;
            usuario.Email = usuarioDTO.Email;
            usuario.CodPerfil = usuarioDTO.CodPerfil;
            usuario.CodMesa = usuarioDTO.CodMesa;
            usuario.IndicadorUsuarioAtivo = usuarioDTO.IndicadorUsuarioAtivo;

            var verificaUsuario = _usuarioRepository.VerificaDuplicidadeUsuario(usuario);

            var usuarioAtualizado = _usuarioRepository.UpdateUsuario(usuario);
            return usuarioAtualizado;
        }

        public void DeleteUsuario(int id)
        {
            _usuarioRepository.DeleteUsuario(id);
        }
    }
}
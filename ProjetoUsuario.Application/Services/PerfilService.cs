using ProjetoUsuario.Domain.Entidades;
using ProjetoUsuario.Application.Interfaces;
using ProjetoUsuario.Persistence.Repository;

namespace ProjetoUsuario.Application.Services
{
    public class PerfilService : IPerfilService
    {
        private IPerfilRepository _perfilRepository;

        public PerfilService(IPerfilRepository perfilRepository)
        {
            _perfilRepository = perfilRepository;
        }

        public Perfil Create(Perfil perfil)
        {
            var criarPerfil = _perfilRepository.Create(perfil);
            return criarPerfil;
        }

        public List<Perfil> FindAllPerfil()
        {
            return _perfilRepository.FindAllPerfil();
        }

        public Perfil FindById(int id)
        {
            var perfil = _perfilRepository.FindById(id);
            return perfil;
        }

        public Perfil UpdatePerfil(Perfil perfil)
        {
            var perfilAtualizado = _perfilRepository.UpdatePerfil(perfil);
            return perfilAtualizado;
        }

        public void DeletePerfil(int id)
        {
            _perfilRepository.DeletePerfil(id);
        }
    }
}
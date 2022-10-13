using ProjetoUsuario.Domain.Entidades;
using ProjetoUsuario.Application.Interfaces;
using ProjetoUsuario.Persistence.Repository;
using ProjetoUsuario.Domain.DTO;

namespace ProjetoUsuario.Application.Services
{
    public class PerfilService : IPerfilService
    {
        private IPerfilRepository _perfilRepository;

        public PerfilService(IPerfilRepository perfilRepository)
        {
            _perfilRepository = perfilRepository;
        }

        public Perfil Create(PerfilDTO perfil)
        {
            Perfil criarPerfil = new Perfil();
            criarPerfil.Id = perfil.Id;
            criarPerfil.DescricaoPerfil = perfil.DescricaoPerfil;
            criarPerfil.IndicadorPerfil  = perfil.IndicadorPerfil;
            var novoPerfil = _perfilRepository.Create(criarPerfil);
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

        public Perfil UpdatePerfil(PerfilDTO perfil)
        {
            Perfil criarPerfil = new Perfil();
            criarPerfil.Id = perfil.Id;
            criarPerfil.DescricaoPerfil = perfil.DescricaoPerfil;
            criarPerfil.IndicadorPerfil  = perfil.IndicadorPerfil;
            var perfilAtualizado = _perfilRepository.UpdatePerfil(criarPerfil);
            return perfilAtualizado;
        }

        public void DeletePerfil(int id)
        {
            _perfilRepository.DeletePerfil(id);
        }
    }
}
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
            criarPerfil.DataCriacaoPerfil = DateTime.Now;
            criarPerfil.DataUltimaAtualizacao = DateTime.Now;

            var verificaPefil = _perfilRepository.VerificaDuplicidadePerfil(criarPerfil);
            if(verificaPefil.Equals(false))
            {
                var perfilAtualizado = _perfilRepository.CriarPerfil(criarPerfil);
                return perfilAtualizado;
            }
            return null;
        }

        public List<Perfil> FindAllPerfil()
        {
            return _perfilRepository.BuscarTodosPerfis();
        }

        public Perfil FindById(int id)
        {
            var perfil = _perfilRepository.BuscarPerfilPorId(id);
            if(perfil is null) return null;
            return perfil;
        }

        public Perfil UpdatePerfil(PerfilDTO perfil)
        {
            Perfil criarPerfil = new Perfil();
            criarPerfil.Id = perfil.Id;
            criarPerfil.DescricaoPerfil = perfil.DescricaoPerfil;
            criarPerfil.IndicadorPerfil  = perfil.IndicadorPerfil;
            criarPerfil.DataUltimaAtualizacao = DateTime.Now;
            var perfilAtualizado = _perfilRepository.AtualizarPerfil(criarPerfil);
            return perfilAtualizado;
        }

        public Perfil DeletePerfil(int id)
        {
            var perfilDeletado =_perfilRepository.DeletarPerfil(id);
            return perfilDeletado;
        }
    }
}
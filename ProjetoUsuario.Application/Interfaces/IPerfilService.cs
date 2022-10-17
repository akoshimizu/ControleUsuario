using ProjetoUsuario.Domain.DTO;
using ProjetoUsuario.Domain.Entidades;

namespace ProjetoUsuario.Application.Interfaces
{
    public interface IPerfilService
    {
        Perfil FindById(int id);
        List<Perfil> FindAllPerfil();
        Perfil Create(PerfilDTO perfil);
        Perfil UpdatePerfil(PerfilDTO perfil);
        void DeletePerfil(int id);
        bool VerificaDuplicidadePerfil(PerfilDTO perfil);
    }
}
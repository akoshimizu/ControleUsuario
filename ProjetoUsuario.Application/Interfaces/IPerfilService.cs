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
        Perfil DeletePerfil(int id);
    }
}
using ProjetoUsuario.Domain.Entidades;

namespace ProjetoUsuario.Application.Interfaces
{
    public interface IPerfilService
    {
        Perfil FindById(int id);
        List<Perfil> FindAllPerfil();
        Perfil Create(Perfil perfil);
        Perfil UpdatePerfil(Perfil perfil);
        void DeletePerfil(int id);
    }
}
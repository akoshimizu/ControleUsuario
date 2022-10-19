using ProjetoUsuario.Domain.Entidades;

namespace ProjetoUsuario.Persistence.Repository
{
    public interface IPerfilRepository
    {
        Perfil FindById(int id);
        List<Perfil> FindAllPerfil();
         Perfil Create(Perfil perfil);
         Perfil UpdatePerfil(Perfil perfil);
         Perfil DeletePerfil(int id);
         bool VerificaDuplicidadePerfil(Perfil perfil);
    }
}
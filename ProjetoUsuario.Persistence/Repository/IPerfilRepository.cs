using ProjetoUsuario.Domain.Entidades;

namespace ProjetoUsuario.Persistence.Repository
{
    public interface IPerfilRepository
    {
         Perfil Create(Perfil perfil);
    }
}
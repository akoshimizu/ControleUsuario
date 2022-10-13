using ProjetoUsuario.Domain.Entidades;

namespace ProjetoUsuario.Application.Interfaces
{
    public interface IPerfilService
    {
        Perfil Create(Perfil perfil);
    }
}
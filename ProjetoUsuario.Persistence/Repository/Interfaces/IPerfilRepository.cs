using ProjetoUsuario.Domain.Entidades;

namespace ProjetoUsuario.Persistence.Repository
{
    public interface IPerfilRepository
    {
        Perfil BuscarPerfilPorId(int id);
        List<Perfil> BuscarTodosPerfis();
         Perfil CriarPerfil(Perfil perfil);
         Perfil AtualizarPerfil(Perfil perfil);
         Perfil DeletarPerfil(int id);
         bool VerificaDuplicidadePerfil(Perfil perfil);
    }
}
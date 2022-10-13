using ProjetoUsuario.Domain.Entidades;
using ProjetoUsuario.Persistence.Context;

namespace ProjetoUsuario.Persistence.Repository
{
    public class PerfilRepository : IPerfilRepository
    {
        private readonly MySQLContext _context;

        public PerfilRepository(MySQLContext context)
        {
            _context = context;
        }

        public Perfil Create(Perfil perfil)
        {
            _context.Perfis.Add(perfil);
            _context.SaveChanges();
            return perfil;
        }
    }
}
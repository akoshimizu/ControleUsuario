using Microsoft.EntityFrameworkCore;
using ProjetoUsuario.Domain.Entidades;

namespace ProjetoUsuario.Persistence.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext()
        {
        }

        public MySQLContext(DbContextOptions<MySQLContext>options) : base(options) {}

        public DbSet<Perfil> Perfis {get; set;}
        public DbSet<Usuario> Usuarios {get; set;}
    }
}
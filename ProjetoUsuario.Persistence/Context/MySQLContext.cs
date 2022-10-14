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

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Perfil>()
        //         .Property(p => p.Id)
        //         .HasMaxLength(10);

        //     modelBuilder.Entity<Perfil>()
        //         .Property(p => p.DescricaoPerfil)
        //         .HasMaxLength(100);

        //     modelBuilder.Entity<Perfil>()
        //         .Property(p => p.IndicadorPerfil)
        //         .HasMaxLength(1);
            
        // }
    }
}
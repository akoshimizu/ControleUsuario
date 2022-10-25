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
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<MesaUsuario> MesaUsuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MesaUsuario>()
                .HasKey(me => new {me.UsuarioId, me.MesaId});

            modelBuilder.Entity<Usuario>()
                .HasMany(m => m.MesasUsuarios)
                .WithOne(mu => mu.Usuario)
                .OnDelete(DeleteBehavior.Cascade);

        }
        
    }
}
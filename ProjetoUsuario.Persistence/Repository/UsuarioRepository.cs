using ProjetoUsuario.Domain.Entidades;
using ProjetoUsuario.Persistence.Context;
using ProjetoUsuario.Persistence.Repository.Interfaces;

namespace ProjetoUsuario.Persistence.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MySQLContext _context;

        public UsuarioRepository(MySQLContext context)
        {
            _context = context;
        }
        
        public Usuario Create(Usuario usuario)
        {
            _context.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public List<Usuario> FindAllUsuario()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario FindById(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Id.Equals(id));
            return usuario;
        }

        public Usuario UpdateUsuario(Usuario usuario)
        {
            var usuarioAtualizado = _context.Usuarios.SingleOrDefault(u => u.Id.Equals(usuario.Id));
            if (usuarioAtualizado is not null)
            {
                _context.Entry(usuarioAtualizado).CurrentValues.SetValues(usuario);
                _context.SaveChanges();
                return usuarioAtualizado;
            }
            return null;
        }

        public void DeleteUsuario(int id)
        {
            var usuario = _context.Usuarios.SingleOrDefault(u => u.Id.Equals(id));
            //usuario.IndicadorUsuarioAtivo = false;
            
            _context.Entry(usuario).CurrentValues.SetValues(usuario.IndicadorUsuarioAtivo = false);
            _context.SaveChanges();
        }

        public bool VerificaDuplicidadeUsuario(Usuario Usuario)
        {
            throw new NotImplementedException();
        }
    }
}
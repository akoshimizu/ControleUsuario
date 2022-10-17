using Microsoft.EntityFrameworkCore;
using ProjetoUsuario.Domain.DTO;
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
        
        public Usuario Create(UsuarioDTO usuario)
        {
            Usuario criarUsuario = new Usuario();
            //criarUsuario.Id = usuario.Id;
            criarUsuario.NomeUsuario = usuario.NomeUsuario;
            criarUsuario.Email  = usuario.Email;
            criarUsuario.Perfil = _context.Perfis.First(per => per.Id.Equals(usuario.CodPerfil));
            criarUsuario.CodMesa = usuario.CodMesa;
            criarUsuario.IndicadorUsuarioAtivo = usuario.IndicadorUsuarioAtivo;

            _context.Add(criarUsuario);
            _context.SaveChanges();
            return criarUsuario;


            // bool usuarioValido = VerificaDuplicidadeUsuario(criarUsuario);
            // if(usuarioValido.Equals(false))
            // {
            // _context.Add(criarUsuario);
            // _context.SaveChanges();
            // return criarUsuario;

            // }
            // return null;
        }

        public List<Usuario> FindAllUsuario()
        {
            return _context.Usuarios.Include(p => p.Perfil).ToList();
        }

        public Usuario FindById(int id)
        {
            var usuario = _context.Usuarios.Include(p => p.Perfil).FirstOrDefault(u => u.Id.Equals(id));
            return usuario;
        }

        public Usuario UpdateUsuario(UsuarioDTO usuarioDTO)
        {
            Usuario user = new Usuario();
            var usuarioAtualizado = _context.Usuarios.First(u => u.Id.Equals(usuarioDTO.Id));
            if (usuarioAtualizado != null)
            {
                user.Id = usuarioDTO.Id;
                user.NomeUsuario = usuarioDTO.NomeUsuario;
                user.Email = usuarioAtualizado.Email;
                user.CodMesa = usuarioDTO.CodMesa;
                user.Perfil = _context.Perfis.First(per => per.Id.Equals(usuarioDTO.CodPerfil));
                user.IndicadorUsuarioAtivo = usuarioDTO.IndicadorUsuarioAtivo;
                _context.Update(usuarioAtualizado).CurrentValues.SetValues(user);
                //_context.Entry(usuarioAtualizado).CurrentValues.SetValues(user);
                _context.SaveChanges();
                return usuarioAtualizado;
            }
            return null;
        }

        public void DeleteUsuario(int id)
        {
            var usuario = _context.Usuarios.SingleOrDefault(u => u.Id.Equals(id));
            
            _context.Entry(usuario).CurrentValues.SetValues(usuario.IndicadorUsuarioAtivo = false);
            _context.SaveChanges();
        }

        public bool VerificaDuplicidadeUsuario(Usuario usuario)
        {
            List<Usuario> listaUsuario = _context.Usuarios.ToList();
            foreach (var item in listaUsuario)
            {
                if(item.Email.ToLower().Contains(usuario.Email.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
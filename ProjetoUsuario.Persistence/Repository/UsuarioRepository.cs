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
            try
            {
                Usuario criarUsuario = new Usuario();
                //criarUsuario.Id = usuario.Id;
                criarUsuario.NomeUsuario = usuario.NomeUsuario;
                criarUsuario.Email  = usuario.Email;
                criarUsuario.Perfil = _context.Perfis.First(per => per.Id.Equals(usuario.CodPerfil));
                criarUsuario.Mesa = _context.Mesas.First(m => m.Id.Equals(usuario.CodMesa));
                criarUsuario.IndicadorUsuarioAtivo = usuario.IndicadorUsuarioAtivo;

                bool usuarioValido = VerificaDuplicidadeUsuario(criarUsuario);
                if(usuarioValido is true) return null;

                _context.Add(criarUsuario);
                _context.SaveChanges();
                return criarUsuario;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public List<Usuario> FindAllUsuario()
        {
            try
            {
                return _context.Usuarios.Include(p => p.Perfil).Include(m => m.Mesa).ToList();
                
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public Usuario FindById(int id)
        {
            var usuario = _context.Usuarios.Include(p => p.Perfil).Include(m => m.Mesa).Include(mu => mu.MesasdoUsuario).FirstOrDefault(u => u.Id.Equals(id));
            // usuario.MesasdoUsuario = _context.MesaUsuarios.Where(m => m.Usuario.Equals(usuario.Id)).Include(m => m.Mesa).ToList();
            usuario.MesasdoUsuario = _context.MesaUsuarios.Include(m => m.Mesa).ToList();
            if(usuario is null) return null;
            return usuario;
        }

        public Usuario UpdateUsuario(UsuarioDTO usuarioDTO)
        {
            // Usuario user = new Usuario();
            // var usuarioAtualizado = _context.Usuarios.Include(p => p.Perfil).First(u => u.Id.Equals(usuarioDTO.Id));
            // var perfilAtualizado = _context.Perfis.First(p => p.Id.Equals(usuarioDTO.CodPerfil));
            // if (usuarioAtualizado != null)
            // {
            //     user.Id = usuarioDTO.Id;
            //     user.NomeUsuario = usuarioDTO.NomeUsuario;
            //     user.Email = usuarioAtualizado.Email;
            //     user.CodMesa = usuarioDTO.CodMesa;
            //     // user.Perfil = _context.Perfis.FirstOrDefault(per => per.Id.Equals(usuarioDTO.CodPerfil));


            //     user.Perfil = perfilAtualizado;
            //     // user.Perfil.DescricaoPerfil = perfilAtualizado.DescricaoPerfil;
            //     // user.Perfil.IndicadorPerfil = perfilAtualizado.IndicadorPerfil;
            //     // user.Perfil.DataCriacaoPerfil = perfilAtualizado.DataCriacaoPerfil;
            //     // user.Perfil.DataUltimaAtualizacao = perfilAtualizado.DataUltimaAtualizacao;


            //     user.IndicadorUsuarioAtivo = usuarioDTO.IndicadorUsuarioAtivo;
            //     //_context.Update(usuarioAtualizado).CurrentValues.SetValues(user);
            //     // usuarioAtualizado = user;
            //     _context.Entry(usuarioAtualizado).CurrentValues.SetValues(user);
            //     _context.SaveChanges();
            //     return usuarioAtualizado;
            // }
            // return null;

            var usuarioAtualizado = _context.Usuarios.Include(p => p.Perfil).Include(m => m.Mesa).SingleOrDefault(u => u.Id.Equals(usuarioDTO.Id));
            if(usuarioAtualizado is not null)
            {
                try
                {
                    usuarioAtualizado.Id = usuarioDTO.Id;
                    usuarioAtualizado.NomeUsuario = usuarioDTO.NomeUsuario;
                    //usuarioAtualizado.Email = usuarioDTO.Email;
                    usuarioAtualizado.Perfil = _context.Perfis.First(p => p.Id.Equals(usuarioDTO.CodPerfil));
                    usuarioAtualizado.Mesa = _context.Mesas.First(m => m.Id.Equals(usuarioDTO.CodMesa));
                    usuarioAtualizado.IndicadorUsuarioAtivo = usuarioDTO.IndicadorUsuarioAtivo;
                    _context.SaveChanges();
                    return usuarioAtualizado;
                }
                catch (System.Exception)
                {
                    
                    throw;
                }
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
            var listaUsuario = _context.Usuarios.Include(p => p.Perfil).ToList();
            foreach (var item in listaUsuario)
            {
                if(item.Email.ToLower().Contains(usuario.Email.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        public MesaDTO AdicionarMesa(int id, MesaDTO mesa)
        {
            var usuario = _context.Usuarios.Include(p => p.Perfil).Include(m => m.Mesa).Include(mu => mu.MesasdoUsuario).SingleOrDefault(u => u.Id.Equals(id));
            var mesaAdicionada = _context.Mesas.First(m => m.Id.Equals(mesa.Id));

            //usuario.ListaDeMesas.Add(_context.Mesas.First(m => m.Id.Equals(mesa.Id)));

            MesaUsuario mesaUsuario = new MesaUsuario();
            mesaUsuario.Usuario = usuario;
            mesaUsuario.Mesa = mesaAdicionada;
            _context.Add(mesaUsuario);
            _context.SaveChanges();
            return mesa;
        }
    }
}
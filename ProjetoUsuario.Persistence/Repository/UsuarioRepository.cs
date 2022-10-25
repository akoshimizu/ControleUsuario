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
        
        public Usuario CriarUsuario(UsuarioDTO usuario)
        {
            try
            {
                Usuario criarUsuario = new Usuario();
                //criarUsuario.Id = usuario.Id;
                criarUsuario.NomeUsuario = usuario.NomeUsuario;
                criarUsuario.Email  = usuario.Email;
                criarUsuario.Perfil = _context.Perfis.First(per => per.Id.Equals(usuario.CodPerfil));
                //criarUsuario.Mesa = _context.Mesas.First(m => m.Id.Equals(usuario.CodMesa));
                criarUsuario.IndicadorUsuarioAtivo = usuario.IndicadorUsuarioAtivo;

                bool usuarioValido = VerificaDuplicidadeUsuario(criarUsuario);
                if(usuarioValido is true) return null;

                //Mesas - Para cada código de mesa informado, verificar se a mesa existe e vincular ao usuário
                criarUsuario.MesasUsuarios = new List<MesaUsuario>();
                foreach (var mesa in usuario.Mesas)
                {
                    //Deve ser find, mas depende da configuração
                    var mesaCadastrada = _context.Mesas.Find(mesa);
                    if(mesaCadastrada != null)
                    {
                        criarUsuario.MesasUsuarios.Add(new MesaUsuario()
                        {
                            Mesa = mesaCadastrada,
                            Usuario = criarUsuario
                        });
                    }                    
                }

                _context.Add(criarUsuario);
                _context.SaveChanges();
                return criarUsuario;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public List<Usuario> BuscarTodosUsuarios()
        {
                // IQueryable<Usuario> query = _context.Usuarios.
                // Include(p => p.Perfil)
                //     .Include(m => m.Mesa)
                //     .Include(u => u.MesasUsuarios)
                //     .ThenInclude(mu => mu.Mesa);

                //     return query;

                var user = _context.Usuarios
                    .Include(p => p.Perfil)
                    .Include(m => m.MesasUsuarios)
                    .ThenInclude(m => m.Mesa);

                return user.ToList();
                // return _context.Usuarios
                //     .Include(p => p.Perfil)
                //     //.Include(m => m.Mesa)
                //     .Include(u => u.MesasUsuarios)
                //     .ThenInclude(mu => mu.Mesa)
                //     .ToList();
        }

        public Usuario BuscarUsuarioPorId(int id)
        {
            //Felipe
            var usuario = _context
                        .Usuarios
                        .Include(x => x.Perfil)
                        .Include(x => x.MesasUsuarios)
                            .ThenInclude(x => x.Mesa)
                        .AsNoTracking()
                        .FirstOrDefault(x => x.Id == id);

            //var usuario = _context.Usuarios.Include(p => p.Perfil).FirstOrDefault(u => u.Id.Equals(id));
            // usuario.MesasdoUsuario = _context.MesaUsuarios.Where(m => m.Usuario.Equals(usuario.Id)).Include(m => m.Mesa).ToList();
            //usuario.MesasdoUsuario = _context.MesaUsuarios.Include(m => m.Mesa).ToList();
            if(usuario is null) return null;
            return usuario;
        }

        public List<MesaUsuario> BuscarMesasDoUsuario(int id)
        {
            var mesasDoUsuario = _context.MesaUsuarios.Include(m => m.Mesa).Where(m => m.Usuario.Id.Equals(id)).ToList();
            return mesasDoUsuario;
        }

        public Usuario AtualizarUsuario(UsuarioDTO usuarioDTO)
        {
            var usuarioAtualizado = _context.Usuarios.Include(p => p.Perfil).SingleOrDefault(u => u.Id.Equals(usuarioDTO.Id));
            if(usuarioAtualizado is not null)
            {
                try
                {
                    usuarioAtualizado.Id = usuarioDTO.Id;
                    usuarioAtualizado.NomeUsuario = usuarioDTO.NomeUsuario;
                    //usuarioAtualizado.Email = usuarioDTO.Email;
                    usuarioAtualizado.Perfil = _context.Perfis.First(p => p.Id.Equals(usuarioDTO.CodPerfil));
                    //usuarioAtualizado.Mesa = _context.Mesas.First(m => m.Id.Equals(usuarioDTO.CodMesa));
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

        public void DeletarUsuario(int id)
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
            var mesasDoUsuario = _context.MesaUsuarios.Include(m => m.Mesa).Where(m => m.Usuario.Id.Equals(id)).ToList();
            if(mesasDoUsuario.Count() >=10) return null;

            var usuario = _context.Usuarios.Include(p => p.Perfil).Include(mu => mu.MesasUsuarios).SingleOrDefault(u => u.Id.Equals(id));
            var mesaAdicionada = _context.Mesas.First(m => m.Id.Equals(mesa.Id));
            
            //if(usuario.Mesa.Id.Equals(mesa.Id))return null;     //PRECISA ARRUMAR,   VOLTA NULO MAS DEVE MOSTRAR MENSAGEM DE MESA EXISTENTE.

            MesaUsuario mesaUsuario = new MesaUsuario();
            mesaUsuario.Usuario = usuario;
            mesaUsuario.Mesa = mesaAdicionada;
            _context.Add(mesaUsuario);
            _context.SaveChanges();
            return mesa;
        }
    }
}
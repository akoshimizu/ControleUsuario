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

        public List<Usuario> BuscarTodosUsuarios()
        {
                var user = _context.Usuarios
                    .Include(p => p.Perfil)
                    .Include(m => m.MesasUsuarios)
                        .ThenInclude(m => m.Mesa);

                return user.ToList();
        }

        public Usuario BuscarUsuarioPorId(int id)
        {
            //Felipe
            var usuario = _context
                        .Usuarios
                        .Include(x => x.Perfil)
                        .Include(x => x.Mesa)
                        .Include(x => x.MesasUsuarios)
                           .ThenInclude(x => x.Mesa)
                        .AsNoTracking()
                        .FirstOrDefault(x => x.Id == id);
            if(usuario is null) return null;
            return usuario;
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
                criarUsuario.Mesa = _context.Mesas.First(m => m.Id.Equals(usuario.CodMesa));
                criarUsuario.IndicadorUsuarioAtivo = usuario.IndicadorUsuarioAtivo;
                criarUsuario.DataCriacaoPerfil = DateTime.Now;
                criarUsuario.DataUltimaAtualizacao = DateTime.Now;

                bool usuarioValido = VerificaDuplicidadeUsuario(criarUsuario);
                if(usuarioValido is true) return null;

                //Mesas - Para cada código de mesa informado, verificar se a mesa existe e vincular ao usuário
                
                if(usuario.Mesas.Contains(criarUsuario.Mesa.Id)) return null;

                var count = 0;
                criarUsuario.MesasUsuarios = new List<MesaUsuario>();
                foreach (var mesa in usuario.Mesas)
                {
                    //Deve ser find, mas depende da configuração
                    var mesaCadastrada = _context.Mesas.Find(mesa);
                    if(mesaCadastrada != null &&   mesaCadastrada.Id != count)
                    {
                        criarUsuario.MesasUsuarios.Add(new MesaUsuario()
                        {
                            Mesa = mesaCadastrada,
                            Usuario = criarUsuario
                        });
                        count = mesaCadastrada.Id;
                    }
                    else{
                    return null;}                   
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

        public Usuario AtualizarUsuario(UsuarioDTO usuarioDTO)
        {
            var usuarioAtualizado = _context.Usuarios.Include(p => p.Perfil).Include(m => m.MesasUsuarios).SingleOrDefault(u => u.Id.Equals(usuarioDTO.Id));
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


                    for (int i = 0; i < usuarioDTO.Mesas.Count; i++)
                    {
                        usuarioAtualizado.MesasUsuarios[i].MesaId = 
                                usuarioDTO.Mesas[i] == usuarioAtualizado.MesasUsuarios[i].MesaId ? 
                                        usuarioAtualizado.MesasUsuarios[i].MesaId : usuarioDTO.Mesas[i];                        
                    }






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
    }
}
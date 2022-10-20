using Microsoft.EntityFrameworkCore;
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

        public Perfil CriarPerfil(Perfil perfil)
        {
            _context.Perfis.Add(perfil);
            _context.SaveChanges();
            return perfil;
        }

        public List<Perfil> BuscarTodosPerfis()
        {
            return _context.Perfis.ToList();
        }

        public Perfil BuscarPerfilPorId(int id)
        {
            var perfil = _context.Perfis.FirstOrDefault(p => p.Id.Equals(id));
            return perfil;
        }

        public Perfil AtualizarPerfil(Perfil perfil)
        {
            var perfilAtualizado = _context.Perfis.SingleOrDefault(p => p.Id ==perfil.Id);
            if(perfilAtualizado != null)
            {
                try
                {
                    perfilAtualizado.Id = perfil.Id;
                    perfilAtualizado.DescricaoPerfil = perfil.DescricaoPerfil;
                    perfilAtualizado.DataCriacaoPerfil = perfilAtualizado.DataCriacaoPerfil;
                    perfilAtualizado.DataUltimaAtualizacao = perfil.DataUltimaAtualizacao;
                    perfilAtualizado.IndicadorPerfil = perfil.IndicadorPerfil;
                    //_context.Entry(perfilAtualizado).CurrentValues.SetValues(perfil);
                    _context.SaveChanges();
                    return perfilAtualizado;
                }
                catch (System.Exception)
                {
                    
                    throw;
                }
            }
            return null;
        }

        public Perfil DeletarPerfil(int id)
        {

            var usuarioVinculado = _context.Usuarios.Include(p => p.Perfil).ToList();
            foreach (var item in usuarioVinculado)
            {
                if(item.Perfil.Id.Equals(id)) return null;
            }

            var perfilDeletado = _context.Perfis.SingleOrDefault(p => p.Id == id);
            if(perfilDeletado != null)
            {
                try
                {
                    _context.Remove(perfilDeletado);
                    _context.SaveChanges();
                    return perfilDeletado;
                }
                catch (System.Exception)
                {
                    
                    throw;
                }
            }
            return null;
        }

        public bool VerificaDuplicidadePerfil(Perfil perfil)
        {
            List<Perfil> listaPerfil = _context.Perfis.ToList();
            foreach (var item in listaPerfil)
            {
                if(item.DescricaoPerfil.ToLower().Contains(perfil.DescricaoPerfil.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
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

        public List<Perfil> FindAllPerfil()
        {
            return _context.Perfis.ToList();
        }

        public Perfil FindById(int id)
        {
            var perfil = _context.Perfis.FirstOrDefault(p => p.Id.Equals(id));
            return perfil;
        }

        public Perfil UpdatePerfil(Perfil perfil)
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

        public void DeletePerfil(int id)
        {
            var perfilDeletado = _context.Perfis.SingleOrDefault(p => p.Id == id);
            if(perfilDeletado != null)
            {
                try
                {
                    _context.Remove(perfilDeletado);
                    _context.SaveChanges();
                }
                catch (System.Exception)
                {
                    
                    throw;
                }
            }
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
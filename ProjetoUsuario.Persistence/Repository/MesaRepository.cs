using ProjetoUsuario.Domain.DTO;
using ProjetoUsuario.Domain.Entidades;
using ProjetoUsuario.Persistence.Context;
using ProjetoUsuario.Persistence.Repository.Interfaces;

namespace ProjetoUsuario.Persistence.Repository
{
    public class MesaRepository : IMesaRepository
    {
        private readonly MySQLContext _context;
        public MesaRepository(MySQLContext context)
        {
            _context = context;
        }

        public Mesa Create(Mesa mesa)
        {
            var duplicidade = VerificaDuplicidadeMesa(mesa);
            if(duplicidade) return null;
            _context.Mesas.Add(mesa);
            _context.SaveChanges();
            return mesa;
        }

        public List<Mesa> FindAllMesa()
        {
            var listaMesas = _context.Mesas.ToList();
            return listaMesas;
        }

        public Mesa FindById(int id)
        {
            var mesa = _context.Mesas.SingleOrDefault(m => m.Id.Equals(id));
            return mesa;
        }

        public Mesa UpdateMesa(MesaDTO mesa)
        {
            var mesaAtualizada = _context.Mesas.SingleOrDefault(m => m.Id.Equals(mesa.Id));
            mesaAtualizada.Id = mesa.Id;
            mesaAtualizada.DescricaoMesa = mesa.DescricaoMesa;
            mesaAtualizada.IndicadorMesaAtiva = mesa.IndicarorMesaAtiva;
            mesaAtualizada.DataDeCriacaoMesa = mesaAtualizada.DataDeCriacaoMesa;
            mesaAtualizada.DataUltimaAlteracaoMesa = DateTime.Now;

            _context.SaveChanges();

            return mesaAtualizada;
        }

        public void DeleteMesa(int id)
        {
            var mesaDesativada = _context.Mesas.SingleOrDefault(m => m.Id.Equals(id));
            mesaDesativada.IndicadorMesaAtiva = false;
            _context.SaveChanges();
        }

        public bool VerificaDuplicidadeMesa(Mesa usuario)
        {
            List<Mesa> listaMesas = _context.Mesas.ToList();
            foreach (var item in listaMesas)
            {
                if(item.DescricaoMesa.Contains(usuario.DescricaoMesa))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
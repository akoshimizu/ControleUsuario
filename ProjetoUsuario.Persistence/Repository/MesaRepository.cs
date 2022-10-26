using Microsoft.EntityFrameworkCore;
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

        public async Task<Mesa> CriarMesa(Mesa mesa)
        {
            var duplicidade = VerificaDuplicidadeMesa(mesa);
            if(duplicidade) return null;
            _context.Mesas.Add(mesa);
            await _context.SaveChangesAsync();
            return mesa;
        }

        public async Task<List<Mesa>> BuscarTodasMesas()
        {
            var listaMesas = await _context.Mesas.ToListAsync();
            return listaMesas;
        }

        public async Task<Mesa> BuscarMesaPorId(int id)
        {
            var mesa = await _context.Mesas.SingleOrDefaultAsync(m => m.Id.Equals(id));
            return mesa;
        }

        public async Task<Mesa> AtualizarMesa(MesaDTO mesa)
        {
            var mesaAtualizada = await _context.Mesas.SingleOrDefaultAsync(m => m.Id.Equals(mesa.Id));
            mesaAtualizada.Id = mesa.Id;
            mesaAtualizada.DescricaoMesa = mesa.DescricaoMesa;
            mesaAtualizada.IndicadorMesaAtiva = mesa.IndicarorMesaAtiva;
            mesaAtualizada.DataDeCriacaoMesa = mesaAtualizada.DataDeCriacaoMesa;
            mesaAtualizada.DataUltimaAlteracaoMesa = DateTime.Now;

            await _context.SaveChangesAsync();

            return mesaAtualizada;
        }

        public async Task<Mesa> DeletarMesa(int id)
        {
            // var mesaVinculada = _context.Usuarios.Include(m => m.Mesa).ToList();
            // foreach (var item in mesaVinculada)
            // {
            //     if(item.Mesa.Id.Equals(id)) return null;
            // }
            try
            {
                var mesaDesativada = await _context.Mesas.SingleOrDefaultAsync(m => m.Id.Equals(id));
            // mesaDesativada.IndicadorMesaAtiva = false;

            _context.Remove(mesaDesativada);
            await _context.SaveChangesAsync();
            return mesaDesativada;
            }
            
            catch (System.Exception)
            {
                
                return null;
            }
            
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